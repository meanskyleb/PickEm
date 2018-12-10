namespace PickEm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEvenMoreStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        WeekId = c.Int(nullable: false),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        HomeTeam = c.String(nullable: false),
                        AwayTeam = c.String(nullable: false),
                        HomeTeamWin = c.Boolean(nullable: false),
                        Team_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.Team_TeamId)
                .Index(t => t.PlayerId)
                .Index(t => t.Team_TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "Team_TeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "PlayerId", "dbo.Player");
            DropIndex("dbo.Game", new[] { "Team_TeamId" });
            DropIndex("dbo.Game", new[] { "PlayerId" });
            DropTable("dbo.Game");
        }
    }
}
