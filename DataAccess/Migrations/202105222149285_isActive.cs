namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "isActive");
        }
    }
}
