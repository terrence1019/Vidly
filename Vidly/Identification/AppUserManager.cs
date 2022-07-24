using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//NAMESPACES REQUIRED FOR AUTHENTICATION AND AUTHORIZATION
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

using Vidly.Identification;
using Vidly.Models;

namespace Vidly.Identification
{
    public class AppUserManager : UserManager<AppUser>
    {

        public AppUserManager(IUserStore<AppUser> store)
        : base(store)
        {
        }

        // this method is called by Owin therefore this is the best place to configure your User Manager
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(
                new UserStore<AppUser>(context.Get<MyDbContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }

    }
}