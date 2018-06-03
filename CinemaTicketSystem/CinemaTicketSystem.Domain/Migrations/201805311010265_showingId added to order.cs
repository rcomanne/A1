namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class showingIdaddedtoorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Showing_Id", "dbo.Showings");
            DropIndex("dbo.Orders", new[] { "Showing_Id" });
            RenameColumn(table: "dbo.Orders", name: "Showing_Id", newName: "ShowingId");
            AlterColumn("dbo.Orders", "ShowingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ShowingId");
            AddForeignKey("dbo.Orders", "ShowingId", "dbo.Showings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShowingId", "dbo.Showings");
            DropIndex("dbo.Orders", new[] { "ShowingId" });
            AlterColumn("dbo.Orders", "ShowingId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "ShowingId", newName: "Showing_Id");
            CreateIndex("dbo.Orders", "Showing_Id");
            AddForeignKey("dbo.Orders", "Showing_Id", "dbo.Showings", "Id");
        }
    }
}
