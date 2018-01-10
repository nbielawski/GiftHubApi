using System;
using System.Collections.Generic;
using System.Linq;
using GiftHub.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GiftHub.API.Startup))]

namespace GiftHub.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@gifthub.com";
                user.Email = "admin@gifthub.com";

                string userPassword = "gifthubadmin";

                var chkUser = userManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "admin");
                }
            }
        }
    }
}
