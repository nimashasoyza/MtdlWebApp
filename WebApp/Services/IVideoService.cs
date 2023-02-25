using System.Collections.Generic;
using WebApp.ViewModels.RequestModels;
using WebApp.ViewModels.ResponseModels;

namespace WebApp.Services
{
    public interface IVideoService
    {
        int Add(VideoRequest videoRequest);
        List<VideoResponse> GetByUser(int userId);
        void Update(VideoResponse videoResponse);
        void Delete(int id);
    }
}
