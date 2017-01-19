using Model.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.MainContext context)
        {
            //  This method will be called after migrating to the latest version.
            Role role = new Role() { Id = 1, Name = "Administrator" };
            Role role_user = new Role() { Id = 2, Name = "User" };
            var user = new User() { Id = 1, Email = "admin@admin.admin", UserName = "admin", Password = "password", Role = role };
            var user2 = new User() { Id = 2, Email = "testuser@gmail.com", UserName = "TestUser", Password = "password", Role = role_user };


            context.Roles.AddOrUpdate(role);
            context.Roles.AddOrUpdate(role_user);
            context.Users.AddOrUpdate(user);
            context.Users.AddOrUpdate(user2);
        }
    }
    }
