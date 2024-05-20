namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Program = c.Int(nullable: false),
                        PersonalStatement = c.String(),
                        ApplicationDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Applications", new[] { "ApplicationUserId" });
            DropTable("dbo.Applications");
        }
    }
}
