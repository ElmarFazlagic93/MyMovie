namespace MyMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "ShowType_Id", "dbo.ShowTypes");
            DropIndex("dbo.Movies", new[] { "ShowType_Id" });
            RenameColumn(table: "dbo.Movies", name: "ShowType_Id", newName: "ShowTypeId");
            AlterColumn("dbo.Movies", "ShowTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "ShowTypeId");
            AddForeignKey("dbo.Movies", "ShowTypeId", "dbo.ShowTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "TypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "TypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "ShowTypeId", "dbo.ShowTypes");
            DropIndex("dbo.Movies", new[] { "ShowTypeId" });
            AlterColumn("dbo.Movies", "ShowTypeId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "ShowTypeId", newName: "ShowType_Id");
            CreateIndex("dbo.Movies", "ShowType_Id");
            AddForeignKey("dbo.Movies", "ShowType_Id", "dbo.ShowTypes", "Id");
        }
    }
}
