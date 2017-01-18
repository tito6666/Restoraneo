namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPluralize : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ReservationClaim", newName: "ReservationClaims");
            RenameTable(name: "dbo.Reservation", newName: "Reservations");
            RenameTable(name: "dbo.Restaurant", newName: "Restaurants");
            RenameTable(name: "dbo.RestaurantDish", newName: "RestaurantDishes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RestaurantDishes", newName: "RestaurantDish");
            RenameTable(name: "dbo.Restaurants", newName: "Restaurant");
            RenameTable(name: "dbo.Reservations", newName: "Reservation");
            RenameTable(name: "dbo.ReservationClaims", newName: "ReservationClaim");
        }
    }
}
