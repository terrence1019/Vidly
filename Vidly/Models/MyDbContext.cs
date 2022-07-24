//REQUIRED FOR EF MIGRATIONS
/*
 * This class had to be created to use the "enable-migrations" command in Nuget Package Manager Console
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//This namespace facilitates Data Migrations
using System.Data.Entity;



/*
 * A DbContext instance represents a combination of the Unit Of Work and Repository patterns
 * such that it can be used to query from a database
 * and group together changes that will then be written back to the store as a unit.
 * DbContext is conceptually similar to ObjectContext.
 */




//Then type in Nuget Package Manager Console:
// Enable-Migrations -ProjectName <YOUR_PROJECT_NAME> -ContextTypeName <YOUR_CONTEXT_NAME>
// In this case:
// Enable-Migrations -ProjectName Vidly -ContextTypeName MyDbContext


//NAMESPACES REQUIRED FOR AUTHENTICATION AND AUTHORIZATION
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

using Vidly.Identification;


namespace Vidly.Models
{
    //[OLD VERSION WITHOUT AUTHENTICATION/AUTHORIZATION]
    //public class MyDbContext : DbContext 

    //[NEW VERSION WITH AUTHENTICATION/AUTHORIZATION]
    public class MyDbContext : IdentityDbContext <AppUser>
    {
        //USE YOUR OWN DESIRED DB OVER DEFAULT CONNECTION
        //https://stackoverflow.com/questions/61107420/how-can-i-make-visual-studio-use-my-database-instead-of-the-mdf-file-located-in
        public MyDbContext() : base("Vidly.Models.MyDbContext")
        {
        }

        //Add Business Logic Models here:
        
        //For Customers:
        public DbSet <Customer> customerDB { get; set; }

        //For MembershipTypes:
        public DbSet <MembershipType> membershipTypeDB { get; set; }

        //For Movies:
        public DbSet <Movie> movieDB { get; set; }




    }
}