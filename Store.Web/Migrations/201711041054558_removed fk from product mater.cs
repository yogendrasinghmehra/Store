namespace Store.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedfkfromproductmater : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductMaster", new[] { "SubCategoryId" });
            AddColumn("dbo.ProductMaster", "ChildCategoryId", c => c.Int());
            AlterColumn("dbo.ProductMaster", "SubCategoryId", c => c.Int());
            CreateIndex("dbo.ProductMaster", "SubCategoryId");
            CreateIndex("dbo.ProductMaster", "ChildCategoryId");
            AddForeignKey("dbo.ProductMaster", "ChildCategoryId", "dbo.ProductChildCategory", "ChildCategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductMaster", "ChildCategoryId", "dbo.ProductChildCategory");
            DropIndex("dbo.ProductMaster", new[] { "ChildCategoryId" });
            DropIndex("dbo.ProductMaster", new[] { "SubCategoryId" });
            AlterColumn("dbo.ProductMaster", "SubCategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductMaster", "ChildCategoryId");
            CreateIndex("dbo.ProductMaster", "SubCategoryId");
        }
    }
}
