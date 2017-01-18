namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingFieldRestaurantIdReservationClaimModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReservationClaims", "RestaurantId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReservationClaims", "RestaurantId", c => c.String());
        }
    }
}
