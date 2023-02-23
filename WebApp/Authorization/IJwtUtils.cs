using WebApp.DataAcces.Entities;

namespace WebApp.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
