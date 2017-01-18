namespace Restoraneo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingOneToManyRelationshipUserRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Restaurant_RestaurantId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Restaurant_RestaurantId");
            AddForeignKey("dbo.AspNetUsers", "Restaurant_RestaurantId", "dbo.Restaurants", "RestaurantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Restaurant_RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.AspNetUsers", new[] { "Restaurant_RestaurantId" });
            DropColumn("dbo.AspNetUsers", "Restaurant_RestaurantId");
        }
    }
}
