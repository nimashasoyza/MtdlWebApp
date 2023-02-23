using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var response = _userService.Authenticate(model);
            return Json(response);
        }

        [HttpPost]
        public IActionResult Register(UserRequest model)
        {
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
        public IActionResult ActiveNewUsers()
        {
            userService.ActiveNewUsers();
            return Json(new { message = "User activate successfully" });
        }
    }
}
