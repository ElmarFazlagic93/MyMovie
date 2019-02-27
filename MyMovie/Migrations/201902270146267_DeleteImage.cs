namespace MyMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Image", c => c.Byte(nullable: false));
        }
    }
}
