using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using lb2mvc.Models;

namespace lb2mvc.Helpers
{
    public class IdentityDbInitializer:CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //base.Seed(context); 
            // Создаем менеджеры ролей и пользователей
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            IdentityRole roleAdmin, roleUser = null;
            ApplicationUser userAdmin = null;

            // поиск роли admin
            roleAdmin = roleManager.FindByName("admin");
            if (roleAdmin == null)
            {
                // создаем, если на нашли 
                roleAdmin = new IdentityRole { Name = "admin" };
                var result = roleManager.Create(roleAdmin);
            }

            // поиск роли user
            roleUser = roleManager.FindByName("user");
            if (roleUser == null)
            {
                // создаем, если на нашли
                roleUser = new IdentityRole { Name = "user" };
                var result = roleManager.Create(roleUser);
            }

            // поиск пользователя admin@mail.ru 
            userAdmin = userManager.FindByEmail("admin@mail.ru");
            if (userAdmin == null)
            {
                // создаем, если на нашли 
                userAdmin = new ApplicationUser
                {
                    NickName = "admin",
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                userManager.Create(userAdmin, "123456");
                // добавляем к роли admin
                userManager.AddToRole(userAdmin.Id, "admin");
            }

        }
        
    }
}