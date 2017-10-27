namespace Store.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChildcategoryAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildCategory",
                c => new
                    {
                        ChildCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ChildCategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ChildCategoryId)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryId)
                .ForeignKey("dbo.ProductSubCategory", t => t.SubCategoryId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChildCategory", "SubCategoryId", "dbo.ProductSubCategory");
            DropForeignKey("dbo.ChildCategory", "CategoryId", "dbo.ProductCategory");
            DropIndex("dbo.ChildCategory", new[] { "CategoryId" });
            DropIndex("dbo.ChildCategory", new[] { "SubCategoryId" });
            DropTable("dbo.ChildCategory");
        }
    }
}
