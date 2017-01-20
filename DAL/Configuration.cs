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
            var user = new User() { Id = 1, Email = "admin@admin.admin", UserName = "admin", Password = "password", Role = role, ImgLink= "http://estrinlegaled.com/wp-content/uploads/2016/02/avatar.png" };
            var user2 = new User() { Id = 2, Email = "testuser2@gmail.com", UserName = "Displeased Horse", Password = "password", Role = role_user, ImgLink = "http://rossknows.com/wp-content/uploads/2015/09/avatar.png" };
            var user3 = new User() { Id = 2, Email = "testuser3@gmail.com", UserName = "Kind Tiger", Password = "password", Role = role_user, ImgLink = "https://www.bigbentobox.com/wp-content/uploads/2014/09/ld.png" };
            var user4 = new User() { Id = 2, Email = "testuser4@gmail.com", UserName = "Strict Bear", Password = "password", Role = role_user, ImgLink = "https://www.bigbentobox.com/wp-content/uploads/2014/09/dv.png" };
            var user5 = new User() { Id = 2, Email = "testuser5@gmail.com", UserName = "Just a Penguin", Password = "password", Role = role_user, ImgLink = "https://www.bigbentobox.com/wp-content/uploads/2014/09/ds.png" };
            var user6 = new User() { Id = 2, Email = "testuser6@gmail.com", UserName = "Cute Panda", Password = "password", Role = role_user, ImgLink = "http://championnat-cgpi.capital.fr/custom/ChallengeAV/assets/images/avatars/33.png" };
            context.Roles.AddOrUpdate(role);
            context.Roles.AddOrUpdate(role_user);
            context.Users.AddOrUpdate(user);
            context.Users.AddOrUpdate(user2);
            context.Users.AddOrUpdate(user3);
            context.Users.AddOrUpdate(user4);
            context.Users.AddOrUpdate(user5);
            context.Users.AddOrUpdate(user6);
        }
    }
    }
