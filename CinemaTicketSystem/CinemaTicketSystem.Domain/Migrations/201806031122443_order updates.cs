namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderupdates : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.Seats");
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowingId = c.Int(nullable: false),
                        NumberOfTickets = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Showings", t => t.ShowingId, cascadeDelete: true)
                .Index(t => t.ShowingId);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => new { t.Row, t.Number }, name: "IX_NumberRowRoom")
                .Index(t => t.Room_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Orders", "ShowingId", "dbo.Showings");
            DropIndex("dbo.Seats", new[] { "Room_Id" });
            DropIndex("dbo.Seats", "IX_NumberRowRoom");
            DropIndex("dbo.Orders", new[] { "ShowingId" });
            DropTable("dbo.Seats");
            DropTable("dbo.Orders");
        }
    }
}
