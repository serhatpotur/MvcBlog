namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "isDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "isTrash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "isRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "isRead");
            DropColumn("dbo.Messages", "isTrash");
            DropColumn("dbo.Messages", "isDraft");
        }
    }
}
