namespace MyMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddType12 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Types", newName: "ShowTypes");
            DropForeignKey("dbo.Movies", "TypeId", "dbo.Types");
            DropIndex("dbo.Movies", new[] { "TypeId" });
            AddColumn("dbo.Movies", "ShowType_Id", c => c.Int());
            CreateIndex("dbo.Movies", "ShowType_Id");
            AddForeignKey("dbo.Movies", "ShowType_Id", "dbo.ShowTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ShowType_Id", "dbo.ShowTypes");
            DropIndex("dbo.Movies", new[] { "ShowType_Id" });
            DropColumn("dbo.Movies", "ShowType_Id");
            CreateIndex("dbo.Movies", "TypeId");
            AddForeignKey("dbo.Movies", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ShowTypes", newName: "Types");
        }
    }
}
