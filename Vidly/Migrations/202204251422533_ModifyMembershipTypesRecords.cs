namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMembershipTypesRecords : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET SubscriptionDuration = 0, RegistrationFee = 0 WHERE MembershipTypeID = 1");
            Sql("UPDATE MembershipTypes SET SubscriptionDuration = 1, RegistrationFee = 10 WHERE MembershipTypeID = 2");
            Sql("UPDATE MembershipTypes SET SubscriptionDuration = 3, RegistrationFee = 30 WHERE MembershipTypeID = 3");
            Sql("UPDATE MembershipTypes SET SubscriptionDuration = 12, RegistrationFee = 110 WHERE MembershipTypeID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
