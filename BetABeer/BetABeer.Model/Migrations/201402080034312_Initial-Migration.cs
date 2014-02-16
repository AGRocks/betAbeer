namespace BetABeer.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        RewardsCount = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        RewardId = c.Long(nullable: false),
                        BookieUserId = c.Long(nullable: false),
                        TheManUserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.BookieUserId, cascadeDelete: false)
                .ForeignKey("dbo.Rewards", t => t.RewardId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.TheManUserId, cascadeDelete: false)
                .Index(t => t.BookieUserId)
                .Index(t => t.RewardId)
                .Index(t => t.TheManUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "TheManUserId", "dbo.Users");
            DropForeignKey("dbo.Bets", "RewardId", "dbo.Rewards");
            DropForeignKey("dbo.Bets", "BookieUserId", "dbo.Users");
            DropIndex("dbo.Bets", new[] { "TheManUserId" });
            DropIndex("dbo.Bets", new[] { "RewardId" });
            DropIndex("dbo.Bets", new[] { "BookieUserId" });
            DropTable("dbo.Rewards");
            DropTable("dbo.Users");
            DropTable("dbo.Bets");
        }
    }
}
