namespace FoodCourtSystem.RecordContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecordModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        TotalRevenue = c.Int(nullable: false),
                        CreatedDay = c.DateTime(nullable: false),
                        Vendor_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VendorModels", t => t.Vendor_ID)
                .Index(t => t.Vendor_ID);
            
            CreateTable(
                "dbo.RecordItemModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Revenue = c.Int(nullable: false),
                        Product_ID = c.String(maxLength: 128),
                        RecordModel_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductModels", t => t.Product_ID)
                .ForeignKey("dbo.RecordModels", t => t.RecordModel_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.RecordModel_ID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecordModels", "Vendor_ID", "dbo.VendorModels");
            DropForeignKey("dbo.RecordItemModels", "RecordModel_ID", "dbo.RecordModels");
            DropForeignKey("dbo.RecordItemModels", "Product_ID", "dbo.ProductModels");
            DropForeignKey("dbo.ProductModels", "Category_ID", "dbo.CategoryModels");
            DropIndex("dbo.RecordItemModels", new[] { "RecordModel_ID" });
            DropIndex("dbo.RecordItemModels", new[] { "Product_ID" });
            DropIndex("dbo.RecordModels", new[] { "Vendor_ID" });
            DropTable("dbo.RecordItemModels");
            DropTable("dbo.RecordModels");
        }
    }
}
