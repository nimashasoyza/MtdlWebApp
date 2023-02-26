using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WebApp.Helpers;
using WebApp.Services;
using WebApp.ViewModels.RequestModels;

namespace WebApp.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            if (model == null)
                throw new Exception("request body is required");

            var response = _userService.Authenticate(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserRequest model)
        {
            if (model == null)
                throw new Exception("request body is required");

            _userService.Register(model);
            return Json(new { message = "Registration successful" });
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);
            return Json(user);
        }

        [HttpPut]
        public IActionResult Update(int id, UserRequest model)
        {
            if (model == null)
                throw new Exception("request body is required");

            _userService.Update(id, model);
            return Json(new { message = "User updated successfully" });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Json(new { message = "User deleted successfully" });
        }

        [HttpGet]
        public IActionResult GetNewUsers()
        {
            var Ids = _userService.GetNewUsers();
            return Json(Ids);
        }

        [HttpGet]
        public IActionResult ActiveNewUsers(List<int> ids)
        {
            _userService.ActiveNewUsers(ids);
            return Json(new { message = "Users activated successfully" });
        }

        [HttpGet]
        public IActionResult GetConsultants()
        {
            var users =_userService.GetConsultants();
            return Json(users);
        }
    }
}
