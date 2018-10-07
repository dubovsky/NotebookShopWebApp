using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace lb2mvc.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("nick", this.NickName));
            return userIdentity;
        }
        public string NickName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IdentityConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            var context= new ApplicationDbContext();
            CheckRoles(context);
            return context;
                
        }
        static void CheckRoles(ApplicationDbContext context)
        { 
            // Создаем менеджеры ролей и пользователей
            RoleManager<IdentityRole> roleManager =  new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); 
            IdentityRole roleAdmin, roleUser = null;
            ApplicationUser userAdmin = null;

            // поиск роли admin
            roleAdmin =  roleManager.FindByName("admin");
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
                    NickName = "admin", Email = "admin@mail.ru", UserName = "admin@mail.ru"
                };
                userManager.Create(userAdmin, "123456");
                // добавляем к роли admin
                userManager.AddToRole(userAdmin.Id, "admin"); 
            }
        } 
    }
}