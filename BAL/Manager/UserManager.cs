using AutoMapper;
using BAL.Interface;
using DAL.Interface;
using Model.DB;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Manager
{
    public class UserManager : BaseManager, IUserManager
    {
        public UserManager(IUnitOfWork uOW)
            : base(uOW)
        {
        }

        /// <summary>
        /// Get all users from db.
        /// </summary>
        /// <returns></returns>
        public List<UserDTO> GetAll()
        {
            var users = new List<UserDTO>();
            foreach (var user in uOW.UserRepo.All.ToList())
            {
                var User = uOW.UserRepo.GetByID(user.Id);
                users.Add(Mapper.Map<UserDTO>(User));
            }
            return users;
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDTO GetById(int id)
        {
            var user = uOW.UserRepo.GetByID(id);
            if (user == null) return null;
            var result = Mapper.Map<UserDTO>(user);

            return result;
        }


        /// <summary>
        /// Get user by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDTO GetByEmail(string email, string password)
        {
            var user = uOW.UserRepo.All
                .FirstOrDefault(x => x.Email == email && x.Password == password);
            return Mapper.Map<UserDTO>(user);
        }
        /// <summary>
        /// Get user by userName and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDTO GetByUserName(string userName, string password)
        {
            var user = uOW.UserRepo.All
                .FirstOrDefault(x => x.UserName == userName && x.Password == password);
            return Mapper.Map<UserDTO>(user);
        }

        public string GetEmail(int Id)
        {
            var email = uOW.UserRepo.GetByID(Id).Email;
            return email;
        }


        /// <summary>
        /// Insert user into database
        /// </summary>
        /// <param name="user">UserDTO</param>
        public void Insert(UserDTO user)
        {
            if (user == null) return;
            User dbUser = Mapper.Map<User>(user);
            dbUser.RoleId = 2;
            uOW.UserRepo.Insert(dbUser);
            uOW.Save();
        }

        /// <summary>
        /// Check the email's existance in database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
		public bool EmailIsExist(string email)
        {
            return uOW.UserRepo.All.Any(x => x.Email == email);
        }

        public List<UserDTO> SearchByName(string name)
        {
            var users = new List<User>();
            if (name != null)
                users = uOW.UserRepo.All.Where(x => x.UserName.Contains(name)).ToList();
            else
                users = uOW.UserRepo.All.ToList();

            var resultListOfUsers = new List<UserDTO>();

            foreach (var user in users)
            {
                resultListOfUsers.Add(Mapper.Map<UserDTO>(user));
            }

            return resultListOfUsers;
        }
    }
}
