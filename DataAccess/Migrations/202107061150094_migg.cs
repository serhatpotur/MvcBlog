namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminPasswordSalt");
        }
    }
}
