namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchoolRecords", "ApplicationUserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.SchoolRecords", "ApplicationUserId", "dbo.SchoolBackgrounds", "ApplicationUserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolRecords", "ApplicationUserId", "dbo.SchoolBackgrounds");
            AddForeignKey("dbo.SchoolRecords", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
