namespace UIJCCA.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            /*DropForeignKey("dbo.AspNetUsers", "idpost", "dbo.Posts");
            DropIndex("dbo.AspNetUsers", new[] { "idpost" });
            AlterColumn("dbo.AspNetUsers", "idpost", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.AspNetUsers", "idpost");
            AddForeignKey("dbo.AspNetUsers", "idpost", "dbo.Posts", "post", cascadeDelete: true);*/
        }
        
        public override void Down()
        {
            /*DropForeignKey("dbo.AspNetUsers", "idpost", "dbo.Posts");
            DropIndex("dbo.AspNetUsers", new[] { "idpost" });
            AlterColumn("dbo.AspNetUsers", "idpost", c => c.String(maxLength: 50));
            CreateIndex("dbo.AspNetUsers", "idpost");
            AddForeignKey("dbo.AspNetUsers", "idpost", "dbo.Posts", "post");*/
        }
    }
}
