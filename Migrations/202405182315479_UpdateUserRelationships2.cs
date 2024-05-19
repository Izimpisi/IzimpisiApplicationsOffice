namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "HasApplied", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "HasApplied");
        }
    }
}
