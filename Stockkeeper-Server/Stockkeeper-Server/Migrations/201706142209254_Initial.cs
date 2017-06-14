namespace Stockkeeper_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        World = c.Int(nullable: false),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        Z = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stacks",
                c => new
                    {
                        ContainerId = c.String(nullable: false, maxLength: 128),
                        Slot = c.Int(nullable: false),
                        ItemId = c.Int(),
                        Count = c.Int(),
                    })
                .PrimaryKey(t => new { t.ContainerId, t.Slot })
                .ForeignKey("dbo.Containers", t => t.ContainerId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ContainerId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnLocalizedName = c.String(),
                        StackLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stacks", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Stacks", "ContainerId", "dbo.Containers");
            DropIndex("dbo.Stacks", new[] { "ItemId" });
            DropIndex("dbo.Stacks", new[] { "ContainerId" });
            DropTable("dbo.Items");
            DropTable("dbo.Stacks");
            DropTable("dbo.Containers");
        }
    }
}
