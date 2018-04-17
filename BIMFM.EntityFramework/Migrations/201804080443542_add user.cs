namespace BIMFM.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class adduser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "Company", c => c.String());
            AddColumn("dbo.AbpUsers", "Pictures", c => c.String());
            
        }

        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "Company");
            DropColumn("dbo.AbpUsers", "Pictures");
        }
    }
}
