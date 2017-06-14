namespace Stockkeeper_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorHandling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTimeOffset(nullable: false, precision: 7),
                        ExceptionMessage = c.String(),
                        InnerException = c.String(),
                        StackTrace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ErrorLogs");
        }
    }
}
