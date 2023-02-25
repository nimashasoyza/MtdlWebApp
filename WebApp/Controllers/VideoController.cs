using Microsoft.AspNetCore.Mvc;
using System;
using WebApp.Services;
using WebApp.ViewModels.RequestModels;
using WebApp.ViewModels.ResponseModels;

namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] VideoRequest model)
        {
            if (model == null)
                throw new Exception("request body is required");

            var id = _videoService.Add(model);
            return Json(id);
        }

        [HttpGet]
        public IActionResult GetByUser(int userId)
        {
            var videos = _videoService.GetByUser(userId);
            return Json(videos);
        }

        [HttpPut]
        public IActionResult Update([FromBody] VideoResponse model)
        {
            if (model == null)
                throw new Exception("request body is required");

            _videoService.Update(model);
            return Json(new { message = "Assigment updated successfully" });
        }

        [HttpDelete]
        public IActionResult Delete(int videoId)
        {
            _videoService.Delete(videoId);
            return Json(new { message = "Video record deleted successfully" });
        }

        [HttpPost]
        public IActionResult Upload()
        {
            return Ok();
        }
    }
}
