namespace MyMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RateNumber = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieStars",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Star_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Star_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stars", t => t.Star_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Star_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieStars", "Star_Id", "dbo.Stars");
            DropForeignKey("dbo.MovieStars", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Ratings", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieStars", new[] { "Star_Id" });
            DropIndex("dbo.MovieStars", new[] { "Movie_Id" });
            DropIndex("dbo.Ratings", new[] { "MovieId" });
            DropTable("dbo.MovieStars");
            DropTable("dbo.Ratings");
            DropTable("dbo.Movies");
            DropTable("dbo.Stars");
        }
    }
}
