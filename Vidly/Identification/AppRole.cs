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


namespace Vidly.Identification
{
    public class AppRole : IdentityRole
    {

        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }

    }
}