namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfTickets = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        Showing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Showings", t => t.Showing_Id)
                .Index(t => t.Showing_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Showing_Id", "dbo.Showings");
            DropIndex("dbo.Orders", new[] { "Showing_Id" });
            DropTable("dbo.Orders");
        }
    }
}
