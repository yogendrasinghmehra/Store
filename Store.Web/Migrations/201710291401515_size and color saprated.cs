namespace Store.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sizeandcolorsaprated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductMaster", "ColorId", "dbo.ProductColor");
            DropForeignKey("dbo.ProductMaster", "SizeId", "dbo.ProductSize");
            DropIndex("dbo.ProductMaster", new[] { "ColorId" });
            DropIndex("dbo.ProductMaster", new[] { "SizeId" });
            CreateTable(
                "dbo.ProductColorMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductColor", t => t.ColorId)
                .ForeignKey("dbo.ProductMaster", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.ProductSizeMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductMaster", t => t.ProductId)
                .ForeignKey("dbo.ProductSize", t => t.SizeId)
                .Index(t => t.ProductId)
                .Index(t => t.SizeId);
            
            DropColumn("dbo.ProductMaster", "ColorId");
            DropColumn("dbo.ProductMaster", "SizeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductMaster", "SizeId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductMaster", "ColorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductSizeMaster", "SizeId", "dbo.ProductSize");
            DropForeignKey("dbo.ProductSizeMaster", "ProductId", "dbo.ProductMaster");
            DropForeignKey("dbo.ProductColorMaster", "ProductId", "dbo.ProductMaster");
            DropForeignKey("dbo.ProductColorMaster", "ColorId", "dbo.ProductColor");
            DropIndex("dbo.ProductSizeMaster", new[] { "SizeId" });
            DropIndex("dbo.ProductSizeMaster", new[] { "ProductId" });
            DropIndex("dbo.ProductColorMaster", new[] { "ColorId" });
            DropIndex("dbo.ProductColorMaster", new[] { "ProductId" });
            DropTable("dbo.ProductSizeMaster");
            DropTable("dbo.ProductColorMaster");
            CreateIndex("dbo.ProductMaster", "SizeId");
            CreateIndex("dbo.ProductMaster", "ColorId");
            AddForeignKey("dbo.ProductMaster", "SizeId", "dbo.ProductSize", "SizeId");
            AddForeignKey("dbo.ProductMaster", "ColorId", "dbo.ProductColor", "ColorId");
        }
    }
}
