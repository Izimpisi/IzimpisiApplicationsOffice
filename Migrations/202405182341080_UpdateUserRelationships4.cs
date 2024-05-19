namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PersonalInfoes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SchoolBackgrounds", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.PersonalInfoes", "ApplicationUserId");
            DropColumn("dbo.SchoolBackgrounds", "ApplicationUserId");
            RenameColumn(table: "dbo.PersonalInfoes", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.SchoolBackgrounds", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            DropPrimaryKey("dbo.PersonalInfoes");
            DropPrimaryKey("dbo.SchoolBackgrounds");
            AlterColumn("dbo.PersonalInfoes", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SchoolBackgrounds", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PersonalInfoes", "ApplicationUserId");
            AddPrimaryKey("dbo.SchoolBackgrounds", "ApplicationUserId");
            CreateIndex("dbo.PersonalInfoes", "ApplicationUserId");
            CreateIndex("dbo.SchoolBackgrounds", "ApplicationUserId");
            DropColumn("dbo.PersonalInfoes", "Id");
            DropColumn("dbo.SchoolBackgrounds", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolBackgrounds", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PersonalInfoes", "Id", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.SchoolBackgrounds", new[] { "ApplicationUserId" });
            DropIndex("dbo.PersonalInfoes", new[] { "ApplicationUserId" });
            DropPrimaryKey("dbo.SchoolBackgrounds");
            DropPrimaryKey("dbo.PersonalInfoes");
            AlterColumn("dbo.SchoolBackgrounds", "ApplicationUserId", c => c.String(nullable: false));
            AlterColumn("dbo.PersonalInfoes", "ApplicationUserId", c => c.String(nullable: false));
            AddPrimaryKey("dbo.SchoolBackgrounds", "Id");
            AddPrimaryKey("dbo.PersonalInfoes", "Id");
            RenameColumn(table: "dbo.SchoolBackgrounds", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.PersonalInfoes", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.SchoolBackgrounds", "ApplicationUserId", c => c.String(nullable: false));
            AddColumn("dbo.PersonalInfoes", "ApplicationUserId", c => c.String(nullable: false));
            CreateIndex("dbo.SchoolBackgrounds", "ApplicationUser_Id");
            CreateIndex("dbo.PersonalInfoes", "ApplicationUser_Id");
        }
    }
}
