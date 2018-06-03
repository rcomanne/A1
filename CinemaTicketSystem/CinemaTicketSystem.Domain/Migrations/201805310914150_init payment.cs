namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initpayment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Showing_Id", "dbo.Showings");
            DropIndex("dbo.Orders", new[] { "Showing_Id" });
            DropTable("dbo.Orders");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Orders", "Showing_Id");
            AddForeignKey("dbo.Orders", "Showing_Id", "dbo.Showings", "Id");
        }
    }
}
