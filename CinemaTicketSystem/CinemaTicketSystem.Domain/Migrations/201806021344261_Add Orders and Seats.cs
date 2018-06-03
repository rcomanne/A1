namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersandSeats : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Showings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Showings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "LocationId", "dbo.Locations");
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
                .ForeignKey("dbo.Showings", t => t.ShowingId)
                .Index(t => t.ShowingId);
            
            CreateTable(
                "dbo.OrderSeats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Seats", t => t.SeatId)
                .Index(t => new { t.OrderId, t.SeatId }, unique: true, name: "IX_OrderSeat");
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => new { t.RoomId, t.Row, t.Number }, name: "IX_NumberRowRoom");
            
            AddForeignKey("dbo.Showings", "MovieId", "dbo.Movies", "Id");
            AddForeignKey("dbo.Showings", "RoomId", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Rooms", "LocationId", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Showings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Showings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Orders", "ShowingId", "dbo.Showings");
            DropForeignKey("dbo.Seats", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.OrderSeats", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.OrderSeats", "OrderId", "dbo.Orders");
            DropIndex("dbo.Seats", "IX_NumberRowRoom");
            DropIndex("dbo.OrderSeats", "IX_OrderSeat");
            DropIndex("dbo.Orders", new[] { "ShowingId" });
            DropTable("dbo.Seats");
            DropTable("dbo.OrderSeats");
            DropTable("dbo.Orders");
            AddForeignKey("dbo.Rooms", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Showings", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Showings", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
