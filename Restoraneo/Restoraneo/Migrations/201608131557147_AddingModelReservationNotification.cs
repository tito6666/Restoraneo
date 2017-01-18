namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingModelReservationNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationNotifications",
                c => new
                    {
                        ReservationNotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationNotificationId)
                .ForeignKey("dbo.Reservations", t => t.ReservationNotificationId)
                .Index(t => t.ReservationNotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationNotifications", "ReservationNotificationId", "dbo.Reservations");
            DropIndex("dbo.ReservationNotifications", new[] { "ReservationNotificationId" });
            DropTable("dbo.ReservationNotifications");
        }
    }
}
