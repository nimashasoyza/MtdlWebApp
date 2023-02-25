using System.Collections.Generic;
using System.Linq;
using WebApp.DataAcces;
using WebApp.DataAcces.Entities;
using WebApp.Exceptions;
using WebApp.ViewModels.RequestModels;
using WebApp.ViewModels.ResponseModels;

namespace WebApp.Services
{
    public class VideoService : IVideoService
    {
        private readonly AppDbContext _context;

        public VideoService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(VideoRequest request)
        {
            if (request.UserId <= 0)
                throw new AppException("UserId is Required");

            var data = new Video
            {
                Description = request.Description,
                Title = request.Title,
                UserId = request.UserId,
                UploadLink = request.VideoLink
            };

            var entity = _context.Add(data);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public List<VideoResponse> GetByUser(int userId)
        {
            return _context.TrainingVideo.Where(i => i.UserId == userId).Select(i => new VideoResponse
            {
                Id = i.Id,
                UserId = i.UserId,
                Description = i.Description,
                Title = i.Title,
                VideoLink = i.UploadLink
            }).ToList();
        }

        public void Update(VideoResponse videoResponse)
        {
            var entity = _context.TrainingVideo.FirstOrDefault(i => i.Id == videoResponse.Id);

            if (entity == null)
                throw new AppException("no video's uploaded for this id.");

            entity.Title = videoResponse.Title;
            entity.Description = videoResponse.Description;
            entity.UploadLink = videoResponse.VideoLink;

            _context.TrainingVideo.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var video = _context.TrainingVideo.Find(id);
            if (video == null) throw new KeyNotFoundException("Video information not found");

            _context.TrainingVideo.Remove(video);
            _context.SaveChanges();
        }
    }
}
