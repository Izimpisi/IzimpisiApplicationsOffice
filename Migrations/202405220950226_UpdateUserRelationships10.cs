namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "College", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "College");
        }
    }
}
