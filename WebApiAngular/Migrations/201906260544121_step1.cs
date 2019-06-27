namespace WebApiAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductColor_ID", "dbo.ProductColors");
            DropForeignKey("dbo.Products", "ProductSize_ID", "dbo.ProductSizes");
            DropForeignKey("dbo.Products", "category_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "ProductSize_ID" });
            DropIndex("dbo.Products", new[] { "ProductColor_ID" });
            DropIndex("dbo.Products", new[] { "category_ID" });
            AlterColumn("dbo.Products", "category_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "category_ID");
            AddForeignKey("dbo.Products", "category_ID", "dbo.Categories", "ID", cascadeDelete: true);
            DropColumn("dbo.Products", "ProductSize_ID");
            DropColumn("dbo.Products", "ProductColor_ID");
            DropTable("dbo.ProductColors");
            DropTable("dbo.ProductSizes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductSizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductColors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "ProductColor_ID", c => c.Int());
            AddColumn("dbo.Products", "ProductSize_ID", c => c.Int());
            DropForeignKey("dbo.Products", "category_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_ID" });
            AlterColumn("dbo.Products", "category_ID", c => c.Int());
            CreateIndex("dbo.Products", "category_ID");
            CreateIndex("dbo.Products", "ProductColor_ID");
            CreateIndex("dbo.Products", "ProductSize_ID");
            AddForeignKey("dbo.Products", "category_ID", "dbo.Categories", "ID");
            AddForeignKey("dbo.Products", "ProductSize_ID", "dbo.ProductSizes", "ID");
            AddForeignKey("dbo.Products", "ProductColor_ID", "dbo.ProductColors", "ID");
        }
    }
}
