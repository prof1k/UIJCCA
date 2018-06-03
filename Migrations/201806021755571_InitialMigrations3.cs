namespace UIJCCA.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations3 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.AspNetUsers", "idpost", c => c.String(maxLength: 50));
            //CreateIndex("dbo.AspNetUsers", "idpost");
            //AddForeignKey("dbo.AspNetUsers", "idpost", "dbo.Posts", "post");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "idpost", "dbo.Posts");
            DropIndex("dbo.AspNetUsers", new[] { "idpost" });
            DropColumn("dbo.AspNetUsers", "idpost");
        }
    }
}
