using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//The Namespace where Models are found
//Naming Convention: using <ProjectName>.Models;
using Vidly.Models;
using Vidly.ViewModels;


//Each Controller relates to a specific Model
//Naming Convention: <ModelName>sController
//In this case: MoviesController (Controller) for Movie (Model)

namespace Vidly.Controllers
{   
    //Derived Controllers use the base Controller simply called Controller
    public class MoviesController : Controller
    {
        // GET: Random Movie
        // .../movies/randomizer
        public ViewResult Randomizer()
        {
            var randomSelection = new Movie() {MovieName = "The Batman"};

            return View(randomSelection);
        }

        //Controller: Controllers>MoviesController.cs
        //Action Name: MovieRentalCustomerList()
        //Action Type: ViewResult
        //Uses a ViewModel: ViewModels>RentalViewModel.cs
        //Uses a View: Views>Movies>MovieRentalCustomerList.cshtml
        public ViewResult MovieRentalCustomerList()
        {
            //Creates a movie
            var rentalSelection = new Movie() { MovieName = "The Batman" };

            //Object initialization syntax used.
            //This creates a list of customers
            var rentalCustomers = new List<Customer>
            {
                new Customer {CustomerID = 001, CustomerName = "Adam"},
                new Customer {CustomerID = 002, CustomerName = "Eve"}
            };

            var rentalCustomersView = new RentalViewModel()
            {
                MovieName = rentalSelection,
                MovieRentalCustomers = rentalCustomers
            };



            return View(rentalCustomersView);
        }

        // .../movies/greetings
        public ContentResult Greetings()
        {
            var greeting = "Greetings, user!";
            return Content(greeting);
        }

        // .../movies/welcomeback?=username
        public ActionResult WelcomeBack(string username)
        {
            var greeting = $"Welcome back, {username}!";
            return Content(greeting);
        }

        //Associated with the Router named "Year and Month of Release" in RouteConfig.cs
        // .../movies/releasedate/rel_yr/rel_mth
        public ActionResult ReleaseDate(int Rel_Yr, int Rel_Mth)
        {
            var release_date = $"Movies Released for: {Rel_Yr}-{Rel_Mth}";
            return Content(release_date);
        }


        // ATTRIBUTE ROUTING
        // .../movies/featuredstar/actor
        [Route("movies/featuredstar/{actor}")]
        public ActionResult FeaturedStar(string actor)
        {
            var starring = $"{actor} starred in the following movies: ";
            return Content(starring);
        }




    }
}