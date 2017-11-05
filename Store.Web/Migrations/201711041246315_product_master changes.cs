namespace Store.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_masterchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductMaster", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductMaster", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductMaster", "ModifiedOn");
            DropColumn("dbo.ProductMaster", "CreatedOn");
        }
    }
}
