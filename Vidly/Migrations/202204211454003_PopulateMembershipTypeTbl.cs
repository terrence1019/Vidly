namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeTbl : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (MembershipTypeID, RegistrationFee, SubscriptionDuration, DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (MembershipTypeID, RegistrationFee, SubscriptionDuration, DiscountRate) VALUES (2,1,30,10)");
            Sql("INSERT INTO MembershipTypes (MembershipTypeID, RegistrationFee, SubscriptionDuration, DiscountRate) VALUES (3,3,90,15)");
            Sql("INSERT INTO MembershipTypes (MembershipTypeID, RegistrationFee, SubscriptionDuration, DiscountRate) VALUES (4,12,100,20)");

        }

        public override void Down()
        {
        }
    }
}
