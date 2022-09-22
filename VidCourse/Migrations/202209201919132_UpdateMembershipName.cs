namespace VidCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipName : DbMigration
    {
        public override void Up()
        {
           Sql("UPDATE MembershipTypes SET Name='Daily' WHERE DiscountRate=0");
            Sql("UPDATE MembershipTypes SET Name='Weekly' WHERE DiscountRate=10");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE DiscountRate=15");
            Sql("UPDATE MembershipTypes SET Name='Anual' WHERE DiscountRate=20");


        }

        public override void Down()
        {
        }
    }
}
