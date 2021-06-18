namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        SkillValue = c.String(),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserFullName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "UserID", "dbo.Users");
            DropIndex("dbo.Skills", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Skills");
        }
    }
}
