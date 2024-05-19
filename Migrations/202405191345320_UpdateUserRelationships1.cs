namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Score = c.Int(nullable: false),
                        level = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolRecords", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SchoolRecords", new[] { "ApplicationUserId" });
            DropTable("dbo.SchoolRecords");
        }
    }
}
