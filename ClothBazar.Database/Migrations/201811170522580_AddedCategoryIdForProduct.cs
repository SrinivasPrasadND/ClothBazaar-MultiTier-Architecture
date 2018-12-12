namespace ClothBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryIdForProduct : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Category_ID" });
            AlterColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Category_ID" });
            AlterColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Products", "Category_ID");
        }
    }
}
