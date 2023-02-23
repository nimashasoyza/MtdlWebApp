using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IUserService
    {
        bool IsUserActive(string userName, string password);
    }
}
