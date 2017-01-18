namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldReservationStatusFromStringToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "ReservationStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ReservationStatus", c => c.String());
        }
    }
}
