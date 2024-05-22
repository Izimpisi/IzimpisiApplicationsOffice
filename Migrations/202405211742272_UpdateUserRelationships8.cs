namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.Courses", new[] { "ApplicationId" });
            DropPrimaryKey("dbo.Courses");
            AddColumn("dbo.Applications", "CourseId", c => c.Int());
            AddColumn("dbo.Courses", "CourseId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Courses", "CourseId");
            CreateIndex("dbo.Applications", "CourseId");
            AddForeignKey("dbo.Applications", "CourseId", "dbo.Courses", "CourseId");
            DropColumn("dbo.Courses", "ApplicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ApplicationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Applications", "CourseId", "dbo.Courses");
            DropIndex("dbo.Applications", new[] { "CourseId" });
            DropPrimaryKey("dbo.Courses");
            DropColumn("dbo.Courses", "CourseId");
            DropColumn("dbo.Applications", "CourseId");
            AddPrimaryKey("dbo.Courses", "ApplicationId");
            CreateIndex("dbo.Courses", "ApplicationId");
            AddForeignKey("dbo.Courses", "ApplicationId", "dbo.Applications", "Id");
        }
    }
}
