using System.Collections.Generic;
using WebApp.DataAcces.Entities;
using WebApp.ViewModels.RequestModels;
using WebApp.ViewModels.ResponseModels;

namespace WebApp.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetUserById(int id);
        void Register(UserRequest model);
        void Update(int id, UserRequest model);
        void Delete(int id);
        List<int> GetNewUsers();
    }
}
