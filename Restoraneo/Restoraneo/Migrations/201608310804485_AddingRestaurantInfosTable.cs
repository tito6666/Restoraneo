namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestaurantInfosTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantInfos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.String(),
                        KitchenType = c.String(),
                        HoursOfWork = c.String(),
                        PaymentType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantInfos", "Id", "dbo.Restaurants");
            DropIndex("dbo.RestaurantInfos", new[] { "Id" });
            DropTable("dbo.RestaurantInfos");
        }
    }
}
