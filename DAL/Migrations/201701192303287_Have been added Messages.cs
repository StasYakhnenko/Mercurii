namespace DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HavebeenaddedMessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        GetterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.GetterId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.SenderId, cascadeDelete: false)
                .Index(t => t.SenderId)
                .Index(t => t.GetterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Messages", "GetterId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "GetterId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropTable("dbo.Messages");
        }
    }
}
