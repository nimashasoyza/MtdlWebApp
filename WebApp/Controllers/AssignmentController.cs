using Microsoft.AspNetCore.Mvc;
using System;
using WebApp.Services;
using WebApp.ViewModels.RequestModels;
using WebApp.ViewModels.ResponseModels;

namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AssignmentAddRequest model)
        {
            if (model == null)
                throw new Exception("request body is required");

            var id = _assignmentService.Add(model);
            return Json(id);
        }

        [HttpGet] 
        public IActionResult GetByUserId(int userId)
        {
            var assignments = _assignmentService.GetByUserId(userId);
            return Json(assignments);
        }

        [HttpPut]
        public IActionResult Update([FromBody] AssigmentReponse model)
        {
            if (model == null)
                throw new Exception("request body is required");

            _assignmentService.Update(model);
            return Json(new { message = "Assigment updated successfully" });
        }

        [HttpDelete]
        public IActionResult Delete (int assignmentId)
        {
            _assignmentService.Delete(assignmentId);
            return Json(new { message = "Assigment deleted successfully" });
        }

        [HttpPost]
        public IActionResult CheckResult([FromBody] CheckResultRequest model)
        {
            if (model == null)
                throw new Exception("request body is required");

            var response = _assignmentService.CheckResults(model);
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetResult(int userId)
        {
            var response = _assignmentService.GetResults(userId);
            return Json(response);
        }
    }
}
