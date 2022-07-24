using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//SETTING UP AUTHORIZATION AND AUTHENTICATION
//https://stackoverflow.com/questions/31960433/adding-asp-net-mvc5-identity-authentication-to-an-existing-project


//NAMESPACES REQUIRED FOR AUTHENTICATION AND AUTHORIZATION
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;


namespace Vidly.Models
{
    public class MyIdContext
    {
    }
}