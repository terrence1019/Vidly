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

            if (customersDBRecords == null) return View("ListCustomers");

            return View(customersDBRecords);
        }

        public ViewResult ListCustomersEditable()
        {
            //To load Customer table AND related tables together (Eager Loading),
            //use the Include() method [Requires using System.Data.Entity]
            var customersDBRecords = dbContext.customerDB.Include(c => c.HasAMembershipType);

            if (customersDBRecords == null) return View("ListCustomers");

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


        [Route("Customers/CustomerDetailsEditable/{customerID}")]
        public ActionResult CustomerDetailsEditable(int customerID)
        {
            var customersDBRecords = dbContext.customerDB.SingleOrDefault(c => c.CustomerID == customerID);

            if (customersDBRecords == null) return HttpNotFound();

            return View(customersDBRecords);
        }


        //PART 01: CREATING CUSTOMER RECORDS

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
            var dropdownlist = new CustomerViewModel
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
        public ActionResult CreateCustomerForm(Customer customer)
        {

            //CRITICAL NOTE: IN ORDER TO AUTOMATICALLY MAP THE CUSTOMER IN VIEWMODEL TO CUSTOMER IN MODEL,
            //THE FIELD NAME MUST BE CUSTOMER IN THE VIEWMODEL!
            //This way, CustomerViewModel.Customer.CustomerName == Customer.CustomerName


            var a = customer.CustomerName;
            var b = customer.IsSubscribedToNewsletter;
            var c = customer.MembershipTypeID;



            var customerTable = dbContext.customerDB;

            /*
            customer.CustomerID = customerTable.Count() + 1;
            Assign CustomerID by: getting CustomerID of Previous Record + 1
            */
            int max = -500;

            foreach (var record in customerTable)
            {
                if (record.CustomerID > max)
                    max = record.CustomerID;
            }

            customer.CustomerID = max + 1;

            //Console.WriteLine();
            customerTable.Add(customer);
            dbContext.SaveChanges();



            //Return to /Customers/ListCustomers after changes implemented
            return RedirectToAction("ListCustomers", "Customers");

        }


        //PART 02: EDITING CUSTOMER RECORDS


        //THIS ACTION GETS THE CUSTOMER DATA FROM THE TABLE
        //Since the Form for creating a Customer used a CustomerViewModel,
        //a CustomerViewModel has to be returned through the View
        [Route("Customers/EditCustomer/{custid}")]
        public ActionResult EditCustomer(int custid)
        {

            //Get Customer from Database with the correlated customerid

            //Step 01: Pull up Customer Table
            var customerTable = dbContext.customerDB;

            //Step 02: Find record with matching customerid value
            var customer = customerTable.SingleOrDefault(c => c.CustomerID == custid);

            //If no customer found with the matching customerid value:
            if (customer == null) HttpNotFound();

            //Since Customer records were added using CustomerViewModel,
            //we need to use that for editing:
            var customerVM = new CustomerViewModel
            {
                Customer = customer,
                ListOfMembershipTypes = dbContext.membershipTypeDB.ToList()
                //var membershiptypesTable = dbContext.membershipTypeDB
            };


            //View is returned with Edit Customer Page and instance of ViewModel
            return View("EditCustomer", customerVM);

        }


        

        [HttpPost]
        public ActionResult EditCustomerForm(Customer customer)
        {

            //CRITICAL NOTE: IN ORDER TO AUTOMATICALLY MAP THE CUSTOMER IN VIEWMODEL TO CUSTOMER IN MODEL,
            //THE FIELD NAME MUST BE CUSTOMER IN THE VIEWMODEL!
            //This way, CustomerViewModel.Customer.CustomerName == Customer.CustomerName

            
            var a = customer.CustomerName;
            var b = customer.IsSubscribedToNewsletter;
            var c = customer.MembershipTypeID;

            

            var customerTable = dbContext.customerDB;

            
            //UPDATE DATABASE RECORD USING FORM DATA SENT TO ACTION PARAMETERS:
            //STEP 01: Get Target Customer to be Updated with data from Edit Form
            var targetCustomer = customerTable.Single(x => x.CustomerID == customer.CustomerID);


            //STEP 02: Manually assign method arguments to update field values of the record
            targetCustomer.CustomerName = customer.CustomerName;
            targetCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            targetCustomer.MembershipTypeID = customer.MembershipTypeID;


            //STEP 03: Save Changes to Vidly Database
            dbContext.SaveChanges();



            //Return to /Customers/ListCustomersEditable after changes implemented
            return RedirectToAction("ListCustomersEditable", "Customers");
            
        }

        



    }
}