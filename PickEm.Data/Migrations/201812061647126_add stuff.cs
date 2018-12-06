namespace PickEm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addstuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                        TeamCity = c.String(nullable: false),
                        TeamConference = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Team");
        }
    }
}
