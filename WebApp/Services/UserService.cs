using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WebApp.Authorization;
using WebApp.DataAcces;
using WebApp.DataAcces.Entities;
using WebApp.Exceptions;
using WebApp.ViewModels.RequestModels;
using WebApp.ViewModels.ResponseModels;
using static WebApp.Helpers.Defs;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IJwtUtils _jwtUtils;

        public UserService(AppDbContext context, IJwtUtils jwtUtils)
        {
            _context = context;
            _jwtUtils = jwtUtils;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName.Trim().ToLower() == model.UserName.Trim().ToLower());

            // validate
            if (user == null || user.Password != model.Password  /*!BCrypt.Verify(model.Password, user.PasswordHash)*/)
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = new AuthenticateResponse
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

        public User GetUserById(int id)
        {
            return GetUser(id);
        }

        public void Register(UserRequest model)
        {
            // validate
            if (_context.Users.Any(x => x.UserName == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = new User
            {
                UserName = model.Username,
                Password = model.Password,
                IsActive = false,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Address2 = model.Address2,
                City = model.City,
                Hospital = model.Hospital,
                State = model.State,
                RegistrationNumber = model.RegistrationNumber,
                PostalCode = model.PostalCode,
                MobileNumber = model.MobileNumber,
                Landline = model.Landline,
                RoleId = model.UserRole
            };

            //=====To Do====
            // hash password
            //user.PasswordHash = BCrypt.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UserRequest model)
        {
            var user = GetUser(id);

            // validate
            if (model.Username != user.UserName && _context.Users.Any(x => x.UserName == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            //====TO DO====
            // hash password if it was entered
            //if (!string.IsNullOrEmpty(model.Password))
            //    user.PasswordHash = BCrypt.HashPassword(model.Password);

            user.UserName = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;
            user.Address2 = model.Address2;
            user.City = model.City;
            user.Hospital = model.Hospital;
            user.State = model.State;
            user.RegistrationNumber = model.RegistrationNumber;
            user.PostalCode = model.PostalCode;
            user.MobileNumber = model.MobileNumber;
            user.Landline = model.Landline;

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<UserRequest> GetConsultants()
        {
            return _context.Users.Where(i => i.RoleId == (int)UserRole.Consultant).Select(i => new UserRequest
            {
                FirstName = i.FirstName,
                LastName = i.LastName,
                Hospital = i.Hospital,
                RegistrationNumber = i.RegistrationNumber,
                Id = i.Id
            }).ToList();
        }

        public List<UserActiveResponse> GetNewUsers()
        {
            return _context.Users.Where(i => i.RoleId != (int)UserRole.Admin && !i.IsActive).Select(i => new UserActiveResponse { Id = i.Id, UserName = i.UserName}).ToList();
        }

        public void ActiveNewUsers(List<int> ids)
        {
            var users = _context.Users.Where(i => ids.Contains(i.Id)).ToList();
            foreach (var user in users)
            {
                user.IsActive = true;
            }
            _context.Users.UpdateRange(users);
            _context.SaveChanges();
        }

        private User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        private UserRole GetUserRoleEnum(string description)
        {
            var legalAidTypeList = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToList();
            var descriptionLower = description.ToLower();
            foreach (var enumValue in legalAidTypeList)
            {
                if (GetEnumDescription(enumValue).ToLower() == descriptionLower)
                    return enumValue;
            }
            return UserRole.NA;
        }

        private static string GetEnumDescription(Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }

        
    }
}
