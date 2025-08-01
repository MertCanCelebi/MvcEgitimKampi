﻿namespace MVC_DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 30));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
