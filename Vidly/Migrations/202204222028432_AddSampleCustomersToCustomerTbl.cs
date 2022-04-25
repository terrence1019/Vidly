namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSampleCustomersToCustomerTbl : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Customers (CustomerName, IsSubscribedToNewsletter, MembershipTypeID) VALUES ('Adam',0,1)");
            Sql("INSERT INTO Customers (CustomerName, IsSubscribedToNewsletter, MembershipTypeID) VALUES ('Eve',1,2)");

            //CustomerID is set as an AUTO_INCREMENT PK and doesn't need to be inserted
            //Bool variables from Domain Model fields are rendered as bit variables in database (FALSE - 0, TRUE - 1)
        }
        
        public override void Down()
        {
        }
    }
}
