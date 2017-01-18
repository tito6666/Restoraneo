namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingWrongRestaurantInfoModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestaurantInfoes", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.RestaurantInfoes", new[] { "RestaurantId" });
            DropTable("dbo.RestaurantInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RestaurantInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.String(),
                        KitchenType = c.String(),
                        HoursOfWork = c.String(),
                        PaymentType = c.String(),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateIndex("dbo.RestaurantInfoes", "RestaurantId");
            AddForeignKey("dbo.RestaurantInfoes", "RestaurantId", "dbo.Restaurants", "RestaurantId");
        }
    }
}
