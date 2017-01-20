using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepo { get; }
        IGenericRepository<Role> RoleRepo { get; }
        IGenericRepository<Message> MessageRepo { get; }
        IGenericRepository<Friendship> FriendshipRepo { get; }
        void Dispose();

        int Save();
    }
}
