using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DataAcces;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }


        public bool IsUserActive(string userName, string password)
        {
            bool isActiveUser = false;
            try
            {
                var user = _context.User.Single(i => i.UserName == userName && i.Password == password);
                if (user != null)
                {
                    isActiveUser = user.IsActive;
                }
                return isActiveUser;
            }
            catch (InvalidOperationException)
            {
                return isActiveUser;
            }
        }
    }
}
