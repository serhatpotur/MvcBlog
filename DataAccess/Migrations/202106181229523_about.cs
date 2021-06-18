namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class about : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "isActive");
        }
    }
}
