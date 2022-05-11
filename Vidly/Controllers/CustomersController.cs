using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Requires Models>Customer.cs --> SYNTAX: using ProjectName.Models
using Vidly.Models;

//Requires ViewModels>CustomerSampleViewModel --> SYNTAX: using ProjectName.ViewModels;
using Vidly.ViewModels;

//Required for EagerLoading
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        //EXERCISE:
        //Create a View using a ViewModel and hard-coded data in the Action of the Controller

        //Controller: Controllers>CustomersController.cs
        //Action Name: CustomerSample()
        //Action Type: ViewResult
        //Uses Model in ViewModel: ViewModel>CustomerSampleViewModel.cs
        //View Name: CustomerSample.cshtml
        public ViewResult CustomerSample()
        {

            //List syntax
            var CustomerSample = new List<Customer>
            {
                new Customer {CustomerID = 001, CustomerName = "Frodo"},
                new Customer {CustomerID = 002, CustomerName = "Samwise"}
            };

            //Users the ListOfCustomers field from Class CustomerSampleViewModel
            var CustomerSampleVM = new CustomerSampleViewModel()
            {
                ListOfCustomers = CustomerSample
            };

            return View(CustomerSampleVM);
        }



        //QUERYING A DATABASE
        //[QUERRYING A DATABASE] STEP 01:
        //Need to query the Customers database table?
        //Place an instance of MyDbContext in Customers controller
        private MyDbContext dbContext;


        //[QUERRYING A DATABASE] STEP 02:
        //Initialize dbContext via CustomerController class constructor
        public CustomersController()
        {
            dbContext = new MyDbContext();
        }

        //[QUERRYING A DATABASE] STEP 03:
        //Ensure to properly dispose of instance by overriding the Dispose() method of the Base Controller class
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }


        //[QUERRYING A DATABASE] STEP 04:
        //CONTROLLER ACTION: Create method for viewing Query Results using the DbSet from MyDbContext
        //DbSet for Customers in MyDbContext = customerDB
        public ViewResult ListCustomers()
        {
            var customersDBRecords = dbContext.customerDB;

            if (customersDBRecords == null) return View("NO DATA");

            return View(customersDBRecords);
        }

        
        public ViewResult ListCustomersEagerLoaded()
        {
            //To load Customer table AND related tables together (Eager Loading),
            //use the Include() method [Requires using System.Data.Entity]
            var customersDBRecords = dbContext.customerDB.Include(c => c.HasAMembershipType);

            if (customersDBRecords == null) return View("NO DATA");

            return View(customersDBRecords);
        }
        

        //[QUERRYING A DATABASE] STEP 04:
        //CONTROLLER ACTION: Create methods for showing Customer Details based on CustomerID

        //Using LINQ
        //.../Customers/CustomerDetails/CustomerID
        //EXAMLE: https://localhost:44383/Customers/CustomerDetails/5
        //EXAMLE: https://localhost:44383/Customers/CustomerDetails?CustomerID=5

        // ATTRIBUTE ROUTING
        [Route("Customers/CustomerDetails/{customerID}")]
        public ActionResult CustomerDetails(int customerID)
        {
            var customersDBRecords = dbContext.customerDB.SingleOrDefault(c => c.CustomerID == customerID);

            if (customersDBRecords == null) return HttpNotFound();

            return View(customersDBRecords);
        }



        //FORM ACTIONS
        //FORM 01: Text Field and Checkbox
        public ActionResult AddCustomer()
        {
            return View();
        }

        //FORM 02: Text Field, Checkbox, and Drop-down List
        public ActionResult AddCustomer2()
        {
            //USED TO CREATE THE DROPDOWN LIST

            //STEP 01: take ALL records from the MembershipType Table and make a list
            IEnumerable<MembershipType> membershiptype_list = dbContext.membershipTypeDB.ToList();

            //STEP 02: add the list of Membership Types to the ViewModel
            var dropdownlist = new AddCustomerViewModel
            {
                ListOfMembershipTypes = membershiptype_list
            };

            //The View is returned with the Dropdown list
            return View(dropdownlist);
        }

        //FORM 02: Action for Model Binding
        //Action correlates to the form's Submit Button in the AddCustomer2 View
        //Action Name == Form Name
        //EF will automatically map request data to the specified model used (Customer).
        //This is called Model Binding

        [HttpPost]
        public ActionResult CreateCustomer(AddCustomerViewModel customer)
        {


            var a = customer.Customer.CustomerName;


            var customerTable = dbContext.customerDB;
            customerTable.Add(customer);
            //dbContext.SaveChanges();



            ////Return to /Customers/ListCustomers after changes implemented
            return RedirectToAction("ListCustomers", "Customers");

            //return View();
        }
    }
}