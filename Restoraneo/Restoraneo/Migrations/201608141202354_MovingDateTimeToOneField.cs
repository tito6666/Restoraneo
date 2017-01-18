namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovingDateTimeToOneField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "DateTimeOfReservation", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "DateOfReservation");
            DropColumn("dbo.Reservations", "TimeOfReservation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "TimeOfReservation", c => c.String());
            AddColumn("dbo.Reservations", "DateOfReservation", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Reservations", "DateTimeOfReservation");
        }
    }
}
