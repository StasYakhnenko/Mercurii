using DAL.Interface;
using DAL.Repositories;
using Model.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MainContext context;

        #region Private Repositories
        private IGenericRepository<User> userRepo;
        private IGenericRepository<Role> roleRepo;
        private IGenericRepository<Message> messageRepo;
        private IGenericRepository<Friendship> friendshipRepo;
        #endregion Private Repositories

        public UnitOfWork()
        {
            context = new MainContext();

            roleRepo = new GenericRepository<Role>(context);
            userRepo = new GenericRepository<User>(context);
            messageRepo = new GenericRepository<Message>(context);
            friendshipRepo = new GenericRepository<Friendship>(context);
        }

        #region Repositories Getters
        public IGenericRepository<User> UserRepo
        {
            get
            {
                if (userRepo == null) userRepo = new GenericRepository<User>(context);
                return userRepo;
            }
        }
        public IGenericRepository<Role> RoleRepo
        {
            get
            {
                if (roleRepo == null) roleRepo = new GenericRepository<Role>(context);
                return roleRepo;
            }
        }

        public IGenericRepository<Message> MessageRepo
        {
            get
            {
                if (messageRepo == null) messageRepo = new GenericRepository<Message>(context);
                return messageRepo;
            }
        }

        public IGenericRepository<Friendship> FriendshipRepo
        {
            get
            {
                if (friendshipRepo == null) friendshipRepo = new GenericRepository<Friendship>(context);
                return friendshipRepo;
            }
        }

        #endregion Repositories Getters

        public void UpdateContext()
        {
            context = new MainContext();
        }

        public int Save()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                return 0;
            }
        }

        #region Dispose

        // https://msdn.microsoft.com/ru-ru/library/system.idisposable(v=vs.110).aspx

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose


    }
}
