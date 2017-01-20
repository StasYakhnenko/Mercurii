using Model.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MainContext : DbContext
    {
        public MainContext()
            :base("MercuriiConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public MainContext(string connString)
            : base(connString)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
    }
}
