namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReservationStatusFieldFromBoolToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "ReservationStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ReservationStatus", c => c.Boolean(nullable: false));
        }
    }
}
