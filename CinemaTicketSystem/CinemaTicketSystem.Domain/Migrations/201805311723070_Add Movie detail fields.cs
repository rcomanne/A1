namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviedetailfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ShortDescription", c => c.String());
            AddColumn("dbo.Movies", "SubtitleLanguage", c => c.String());
            AddColumn("dbo.Movies", "Is3D", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "Trailer", c => c.String());
            AddColumn("dbo.Movies", "Imdb", c => c.String());
            AddColumn("dbo.Movies", "WebLink", c => c.String());
            AddColumn("dbo.Movies", "LastShowDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Showings", "Is3D", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Showings", "Is3D");
            DropColumn("dbo.Movies", "LastShowDate");
            DropColumn("dbo.Movies", "WebLink");
            DropColumn("dbo.Movies", "Imdb");
            DropColumn("dbo.Movies", "Trailer");
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Movies", "Is3D");
            DropColumn("dbo.Movies", "SubtitleLanguage");
            DropColumn("dbo.Movies", "ShortDescription");
        }
    }
}
