namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantInfoModelRefactor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantInfoes", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.RestaurantInfoes", "RestaurantInfoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantInfoes", "RestaurantInfoId", c => c.Int(nullable: false));
            DropColumn("dbo.RestaurantInfoes", "Id");
        }
    }
}
