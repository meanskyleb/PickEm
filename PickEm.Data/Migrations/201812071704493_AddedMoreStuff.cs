namespace PickEm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Week",
                c => new
                    {
                        WeekId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        SeasonNumber = c.Int(nullable: false),
                        SeasonWeek = c.Int(nullable: false),
                        StadiumName = c.String(nullable: false),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeekId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Week", "PlayerId", "dbo.Player");
            DropIndex("dbo.Week", new[] { "PlayerId" });
            DropTable("dbo.Week");
        }
    }
}
