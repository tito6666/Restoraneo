namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingFieldClientIdReservationClaimModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReservationClaims", "ClientId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReservationClaims", "ClientId", c => c.Int(nullable: false));
        }
    }
}
