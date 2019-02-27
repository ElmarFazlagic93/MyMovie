namespace MyMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddType1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "TypeId");
            AddForeignKey("dbo.Movies", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "TypeId", "dbo.Types");
            DropIndex("dbo.Movies", new[] { "TypeId" });
            DropColumn("dbo.Movies", "TypeId");
            DropTable("dbo.Types");
        }
    }
}
