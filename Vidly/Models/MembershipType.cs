using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte MembershipTypeID { get; set; }

        public string MembershipName { get; set; }

        public short RegistrationFee { get; set; }
        public byte SubscriptionDuration { get; set; } //0-12 months
        public byte DiscountRate { get; set; } //0-100%



    }
}