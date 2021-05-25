namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heading_isActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "isActive");
        }
    }
}
