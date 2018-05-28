namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_seats_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Available = c.Boolean(nullable: false),
                        Number = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => new { t.Number, t.Row }, unique: true, name: "IX_NumberRowRoom")
                .Index(t => t.Room_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.Seats", new[] { "Room_Id" });
            DropIndex("dbo.Seats", "IX_NumberRowRoom");
            DropTable("dbo.Seats");
        }
    }
}
