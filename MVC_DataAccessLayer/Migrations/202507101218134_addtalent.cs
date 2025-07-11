namespace MVC_DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtalent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        TalentName = c.String(maxLength: 100),
                        TalentLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TalentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talents");
        }
    }
}
