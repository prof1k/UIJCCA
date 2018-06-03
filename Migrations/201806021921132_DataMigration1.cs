namespace UIJCCA.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.Posts",
                c => new
                    {
                        post = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.post);*/
            
            AddColumn("dbo.AspNetUsers", "idpost", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.AspNetUsers", "idpost");
            AddForeignKey("dbo.AspNetUsers", "idpost", "dbo.Posts", "post", cascadeDelete: true);
        }
        
        public override void Down()
        {
            /*DropForeignKey("dbo.AspNetUsers", "idpost", "dbo.Posts");
            DropIndex("dbo.AspNetUsers", new[] { "idpost" });
            DropColumn("dbo.AspNetUsers", "idpost");
            DropTable("dbo.Posts");*/
        }
    }
}
