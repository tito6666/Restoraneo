namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResaturantInfoAndRestaurantDishModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationNotifications", "ReservationNotificationId", "dbo.Reservations");
            DropIndex("dbo.ReservationNotifications", new[] { "ReservationNotificationId" });
            CreateTable(
                "dbo.RestaurantDishes",
                c => new
                    {
                        RestaurantDishId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.String(),
                        Description = c.String(),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantDishId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.RestaurantInfoes",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false),
                        RestaurantInfoId = c.Int(nullable: false),
                        KitchenType = c.String(),
                        HoursOfWork = c.String(),
                        Address = c.String(),
                        Telephone = c.String(),
                        PaymentType = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId)
                .Index(t => t.RestaurantId);
            
            DropTable("dbo.ReservationNotifications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReservationNotifications",
                c => new
                    {
                        ReservationNotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationNotificationId);
            
            DropForeignKey("dbo.RestaurantInfoes", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantDishes", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.RestaurantInfoes", new[] { "RestaurantId" });
            DropIndex("dbo.RestaurantDishes", new[] { "RestaurantId" });
            DropTable("dbo.RestaurantInfoes");
            DropTable("dbo.RestaurantDishes");
            CreateIndex("dbo.ReservationNotifications", "ReservationNotificationId");
            AddForeignKey("dbo.ReservationNotifications", "ReservationNotificationId", "dbo.Reservations", "ReservationId");
        }
    }
}
