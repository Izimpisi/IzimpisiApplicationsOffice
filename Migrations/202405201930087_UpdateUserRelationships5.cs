namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Years = c.Int(nullable: false),
                        MinimumAPS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.Applications", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.Courses", new[] { "ApplicationId" });
            DropTable("dbo.Courses");
        }
    }
}
