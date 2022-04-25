namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignMembershipName_to_MembershipID : DbMigration
    {
        //Conditional Updates:
        //https://chartio.com/learn/sql-tips/how-to-update-a-column-based-on-a-filter-of-another-column/
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName = 'Pay As You Go' WHERE MembershipTypeID = 1");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Monthly' WHERE MembershipTypeID = 2");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Quarterly' WHERE MembershipTypeID = 3");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Annually' WHERE MembershipTypeID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
