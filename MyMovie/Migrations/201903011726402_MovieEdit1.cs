namespace MyMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieEdit1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "ShowTypeId", "dbo.ShowTypes");
            DropIndex("dbo.Movies", new[] { "ShowTypeId" });
            RenameColumn(table: "dbo.Movies", name: "ShowTypeId", newName: "ShowType_Id");
            AddColumn("dbo.Movies", "TypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "ShowType_Id", c => c.Int());
            CreateIndex("dbo.Movies", "ShowType_Id");
            AddForeignKey("dbo.Movies", "ShowType_Id", "dbo.ShowTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ShowType_Id", "dbo.ShowTypes");
            DropIndex("dbo.Movies", new[] { "ShowType_Id" });
            AlterColumn("dbo.Movies", "ShowType_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "TypeId");
            RenameColumn(table: "dbo.Movies", name: "ShowType_Id", newName: "ShowTypeId");
            CreateIndex("dbo.Movies", "ShowTypeId");
            AddForeignKey("dbo.Movies", "ShowTypeId", "dbo.ShowTypes", "Id", cascadeDelete: true);
        }
    }
}
