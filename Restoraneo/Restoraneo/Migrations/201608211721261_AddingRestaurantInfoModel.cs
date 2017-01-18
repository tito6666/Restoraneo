namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestaurantInfoModel : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantInfoes", "Id", "dbo.Restaurants");
            DropIndex("dbo.RestaurantInfoes", new[] { "Id" });
            DropTable("dbo.RestaurantInfoes");
        }
    }
}
