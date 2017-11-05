namespace Store.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productimagechnages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductImages", "User_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ProductImages", new[] { "User_Id" });
            AddColumn("dbo.ProductImages", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductImages", "ProductId");
            AddForeignKey("dbo.ProductImages", "ProductId", "dbo.ProductMaster", "ProductId");
            DropColumn("dbo.ProductImages", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductImages", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.ProductMaster");
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropColumn("dbo.ProductImages", "ProductId");
            CreateIndex("dbo.ProductImages", "User_Id");
            AddForeignKey("dbo.ProductImages", "User_Id", "dbo.ApplicationUser", "Id");
        }
    }
}
