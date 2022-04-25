using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Requires Models>Customer.cs --> SYNTAX: using ProjectName.Models
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerSampleViewModel
    {
        //Build First before Buidling CustomerListControllerAction in Controllers>CustomersController.cs

        
        //FIELD FOR STORING A LIST OF CUSTOMERS
        //Data Type: List
        public List<Customer> ListOfCustomers { get; set; }

    }
}