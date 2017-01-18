namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingReservationClaimModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationClaims",
                c => new
                    {
                        ReservationClaimId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ClientUsername = c.String(),
                        RestaurantId = c.String(),
                        RestaurantName = c.String(),
                        NumberOfPersons = c.String(),
                        DateOfReservation = c.String(),
                        TimeOfReservation = c.String(),
                    })
                .PrimaryKey(t => t.ReservationClaimId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReservationClaims");
        }
    }
}
