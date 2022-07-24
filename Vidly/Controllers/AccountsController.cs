using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

namespace Vidly.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();

        }


        //REQUIRED AUTHENTICATION AND AUTHORIZATION FUNCTIONS EXIST HERE:
        //Register
        //Login
        //Logout



        //REGISTER
        public ActionResult RegisterPage()
        {
            return View();
        }
















    }//AccountsController class
}//Vidly.Controllers namespace