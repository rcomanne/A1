namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandShowing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "Start", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showings", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "Name", c => c.String());
            DropColumn("dbo.Showings", "Start");
        }
    }
}
