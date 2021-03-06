namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wrupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterUsername", c => c.String(maxLength: 20));
            AddColumn("dbo.Writers", "WriterRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterRole");
            DropColumn("dbo.Writers", "WriterUsername");
        }
    }
}
