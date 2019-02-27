namespace MyMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDBC : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovieStars", newName: "StarMovies");
            DropPrimaryKey("dbo.StarMovies");
            AddPrimaryKey("dbo.StarMovies", new[] { "Star_Id", "Movie_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StarMovies");
            AddPrimaryKey("dbo.StarMovies", new[] { "Movie_Id", "Star_Id" });
            RenameTable(name: "dbo.StarMovies", newName: "MovieStars");
        }
    }
}
