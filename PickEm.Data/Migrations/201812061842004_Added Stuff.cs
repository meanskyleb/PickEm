namespace PickEm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Team", "OwnerId");
        }
    }
}
