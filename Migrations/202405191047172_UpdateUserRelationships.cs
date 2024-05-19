namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonalInfoes", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SchoolBackgrounds", "ApplicationUserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.PersonalInfoes", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SchoolBackgrounds", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolBackgrounds", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalInfoes", "ApplicationUserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.SchoolBackgrounds", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PersonalInfoes", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
