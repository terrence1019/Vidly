using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Vidly.Models;

namespace Vidly.ViewModels
{
    public class AddCustomerViewModel
    {   
        //IEnumerable supports simple iteration over a collection of a specific type,
        //e.g., a list of Customer records, a list of MembershipType column values, etc.
        public IEnumerable<MembershipType> ListOfMembershipTypes { get; set; }

        //Since a View can only use one Model at a time, we can create a ViewModel and
        //use "using ProjectName.Models" to get additional Models.
        //We can then add a field to the ViewModel with the desired fields from the other Models
        
        //CRITICAL NOTE: IN ORDER TO AUTOMATICALLY MAP THE CUSTOMER IN VIEWMODEL TO CUSTOMER IN MODEL,
        //THE FIELD NAME MUST BE CUSTOMER IN THE VIEWMODEL!
        //This way, AddCustomerViewModel.Customer.CustomerName == Customer.CustomerName
        public Customer Customer { get; set; }

    }
}