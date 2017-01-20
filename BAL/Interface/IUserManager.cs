using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IUserManager
    {
        UserDTO GetById(int id);
        UserDTO GetByEmail(string email, string password);
        UserDTO GetByUserName(string userName, string password);
        List<UserDTO> GetAll();
        void Insert(UserDTO user);
        string GetEmail(int Id);
        bool EmailIsExist(string email);

        List<UserDTO> SearchByName(string name);
    }
}
