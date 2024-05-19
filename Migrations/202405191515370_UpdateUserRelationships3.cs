namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolBackgrounds", "Province", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchoolBackgrounds", "Province");
        }
    }
}
