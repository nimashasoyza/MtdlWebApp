using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult IsUserActive()
        {
            string userName = "SUP";
            string password = "test";
            var isActive = _userService.IsUserActive(userName, password);

            return Json(isActive);
        }
    }
}
