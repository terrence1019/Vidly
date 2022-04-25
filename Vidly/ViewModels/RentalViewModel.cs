using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RentalViewModel
    {
        public Movie MovieName { get; set; }
        public List<Customer> MovieRentalCustomers { get; set; }
    }
}