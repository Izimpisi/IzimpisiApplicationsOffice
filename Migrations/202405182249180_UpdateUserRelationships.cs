namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonalInfoes", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.SchoolBackgrounds", "ApplicationUser_Id", "dbo.ApplicationUsers");
            AddForeignKey("dbo.PersonalInfoes", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SchoolBackgrounds", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolBackgrounds", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.PersonalInfoes", "ApplicationUser_Id", "dbo.ApplicationUsers");
            AddForeignKey("dbo.SchoolBackgrounds", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.PersonalInfoes", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
        }
    }
}
