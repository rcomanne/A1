namespace CinemaTicketSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class surveyinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OverallExperience = c.Int(nullable: false),
                        MovieExperience = c.Int(nullable: false),
                        TravelExperience = c.Int(nullable: false),
                        BathroomExperience = c.Int(nullable: false),
                        ShopExperience = c.Int(nullable: false),
                        FoodExperience = c.Int(nullable: false),
                        StaffExperience = c.Int(nullable: false),
                        Comment = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Surveys");
        }
    }
}
