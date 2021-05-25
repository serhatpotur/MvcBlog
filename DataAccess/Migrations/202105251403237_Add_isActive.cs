namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_isActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "isActive");
        }
    }
}
