namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewsletterSignup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsletterSignups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        VerificationToken = c.String(),
                        Verified = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsletterSignups");
        }
    }
}
