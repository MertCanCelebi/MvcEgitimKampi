namespace MVC_DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contents", "ContenDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "ContenDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contents", "ContentDate");
        }
    }
}
