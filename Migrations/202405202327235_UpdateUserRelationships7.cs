namespace IzimpisiApplicationsOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserRelationships7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "StartTerm", c => c.Int(nullable: false));
            AddColumn("dbo.Applications", "needResidence", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Applications", "PersonalStatement", c => c.String(nullable: false));
            DropColumn("dbo.Applications", "Program");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "Program", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "PersonalStatement", c => c.String());
            DropColumn("dbo.Applications", "needResidence");
            DropColumn("dbo.Applications", "StartTerm");
        }
    }
}
