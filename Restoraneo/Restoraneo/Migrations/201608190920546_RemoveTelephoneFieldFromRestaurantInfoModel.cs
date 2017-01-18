namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTelephoneFieldFromRestaurantInfoModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RestaurantInfoes", "Telephone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantInfoes", "Telephone", c => c.String());
        }
    }
}
