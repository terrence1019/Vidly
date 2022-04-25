using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Required for Data Annotations
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class MembershipType
    {
        [Display(Name = "Membership Type ID")]
        public byte MembershipTypeID { get; set; }

        [Display(Name = "Membership Type Name")]
        public string MembershipName { get; set; }

        [Display(Name = "Registration Fee")]
        public short RegistrationFee { get; set; }

        [Display(Name = "Subscription Duration")]
        public byte SubscriptionDuration { get; set; } //0-200 months

        [Display(Name = "Discount Rate")]
        public byte DiscountRate { get; set; } //0-100%



    }
}