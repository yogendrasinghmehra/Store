namespace Store.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Childcategoryrenamed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ChildCategory", newName: "ProductChildCategory");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductChildCategory", newName: "ChildCategory");
        }
    }
}
