namespace Store.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderMaster", t => t.OrderId)
                .ForeignKey("dbo.ProductMaster", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderMaster",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false, maxLength: 128),
                        TotalPrice = c.Single(nullable: false),
                        TotalProducts = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        OrderStatusText = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.ProductMaster",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductDescription = c.String(),
                        Price = c.Single(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductBrand", t => t.BrandId)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryId)
                .ForeignKey("dbo.ProductColor", t => t.ColorId)
                .ForeignKey("dbo.ProductSize", t => t.SizeId)
                .ForeignKey("dbo.ProductSubCategory", t => t.SubCategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.BrandId)
                .Index(t => t.ColorId)
                .Index(t => t.SizeId);
            
            CreateTable(
                "dbo.ProductBrand",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductColor",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        ColorText = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.ProductSize",
                c => new
                    {
                        SizeId = c.Int(nullable: false, identity: true),
                        SizeText = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SizeId);
            
            CreateTable(
                "dbo.ProductSubCategory",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ShowThis = c.Boolean(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.ApplicationUser", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Id = c.String(nullable: false, maxLength: 128),
                        ReviewText = c.String(nullable: false),
                        ReviewCount = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReviewId, t.ProductId, t.Id })
                .ForeignKey("dbo.ProductMaster", t => t.ProductId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .Index(t => t.ProductId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ProductReviews", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ProductReviews", "ProductId", "dbo.ProductMaster");
            DropForeignKey("dbo.ProductImages", "User_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.ProductMaster");
            DropForeignKey("dbo.ProductMaster", "SubCategoryId", "dbo.ProductSubCategory");
            DropForeignKey("dbo.ProductSubCategory", "CategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductMaster", "SizeId", "dbo.ProductSize");
            DropForeignKey("dbo.ProductMaster", "ColorId", "dbo.ProductColor");
            DropForeignKey("dbo.ProductMaster", "CategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductMaster", "BrandId", "dbo.ProductBrand");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.OrderMaster");
            DropForeignKey("dbo.OrderMaster", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ProductReviews", new[] { "Id" });
            DropIndex("dbo.ProductReviews", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "User_Id" });
            DropIndex("dbo.ProductSubCategory", new[] { "CategoryId" });
            DropIndex("dbo.ProductMaster", new[] { "SizeId" });
            DropIndex("dbo.ProductMaster", new[] { "ColorId" });
            DropIndex("dbo.ProductMaster", new[] { "BrandId" });
            DropIndex("dbo.ProductMaster", new[] { "SubCategoryId" });
            DropIndex("dbo.ProductMaster", new[] { "CategoryId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.OrderMaster", new[] { "Id" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.ProductImages");
            DropTable("dbo.ProductSubCategory");
            DropTable("dbo.ProductSize");
            DropTable("dbo.ProductColor");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.ProductBrand");
            DropTable("dbo.ProductMaster");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.OrderMaster");
            DropTable("dbo.OrderDetails");
        }
    }
}
