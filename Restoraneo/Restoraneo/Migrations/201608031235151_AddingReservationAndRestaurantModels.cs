namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingReservationAndRestaurantModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        NumberOfPersons = c.Int(nullable: false),
                        DateOfReservation = c.DateTime(nullable: false, storeType: "date"),
                        TimeOfReservation = c.String(),
                        RestaurantId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ReservationStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        TelephoneNumber1 = c.String(),
                        TelephoneNumber2 = c.String(),
                        MobileNumber1 = c.String(),
                        MobileNumber2 = c.String(),
                        Fax = c.String(),
                        NumberOfSeets = c.Int(nullable: false),
                        Lat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Long = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reservations", new[] { "RestaurantId" });
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Reservations");
        }
    }
}
