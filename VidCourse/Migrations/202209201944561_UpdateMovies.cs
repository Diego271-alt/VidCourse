namespace VidCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET GenreId=1, DateAdded=10/12/21,ReleaseDate=10/12/21,NumberInStock=5  WHERE Name='Shrek'");
            Sql("UPDATE Movies SET GenreId=2,DateAdded=10/12/21, ReleaseDate=10/12/21,NumberInStock=1 WHERE Name='Wall-e'");


        }

        public override void Down()
        {
        }
    }
}
