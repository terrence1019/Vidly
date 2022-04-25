using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Required for Data Annotations
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }


        //To override certain default conventions and constraints implemented by EF during table creation,
        //we use Data Annotations in square brackets ABOVE the database table field
        //To enable, we have to use the namespace: 
        [Required] //This annotation makes database table field NOT NULL
        [StringLength(200)] //This annotation limits the database table field's varchar length to 200 - varchar(200)
        [Display (Name="Customer Name")]
        public string CustomerName { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //This is called a Navigation Property, allowing us to move from one class (Customer)
        //to the parent class of the property (MembershipType)
        //Customer HAS-A MembershipType
        public MembershipType HasAMembershipType { get; set; }

        //This the Foreign Key:
        //It is the Primary Key (MembershipTypeID) of the Parent Class (MembershipType)
        [Display(Name = "Customer Membership Type")]
        public byte MembershipTypeID { get; set; }

    }
}