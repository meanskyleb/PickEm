namespace PickEm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStuff1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Team", "TeamName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Team", "TeamName", c => c.String(nullable: false));
        }
    }
}
