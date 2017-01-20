namespace DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedfriendships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirtstFriendId = c.Int(nullable: false),
                        SecondFriendId = c.Int(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FirtstFriendId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.SecondFriendId, cascadeDelete: false)
                .Index(t => t.FirtstFriendId)
                .Index(t => t.SecondFriendId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "SecondFriendId", "dbo.Users");
            DropForeignKey("dbo.Friendships", "FirtstFriendId", "dbo.Users");
            DropIndex("dbo.Friendships", new[] { "SecondFriendId" });
            DropIndex("dbo.Friendships", new[] { "FirtstFriendId" });
            DropTable("dbo.Friendships");
        }
    }
}
