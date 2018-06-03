namespace UIJCCA.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations2 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.AspNetUsers", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
        }
    }
}
