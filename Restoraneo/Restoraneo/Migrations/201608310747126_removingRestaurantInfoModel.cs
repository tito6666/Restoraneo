namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingRestaurantInfoModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ReservationClaims", newName: "ReservationClaim");
            RenameTable(name: "dbo.Reservations", newName: "Reservation");
            RenameTable(name: "dbo.Restaurants", newName: "Restaurant");
            RenameTable(name: "dbo.RestaurantDishes", newName: "RestaurantDish");
            DropForeignKey("dbo.RestaurantInfoes", "Id", "dbo.Restaurants");
            DropIndex("dbo.RestaurantInfoes", new[] { "Id" });
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RestaurantInfoes", "Id");
            AddForeignKey("dbo.RestaurantInfoes", "Id", "dbo.Restaurants", "RestaurantId");
            RenameTable(name: "dbo.RestaurantDish", newName: "RestaurantDishes");
            RenameTable(name: "dbo.Restaurant", newName: "Restaurants");
            RenameTable(name: "dbo.Reservation", newName: "Reservations");
            RenameTable(name: "dbo.ReservationClaim", newName: "ReservationClaims");
        }
    }
}
