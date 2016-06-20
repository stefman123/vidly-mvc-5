namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetAvailableStockEqualToStock : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET AvailableStock = Stock");
        }
        
        public override void Down()
        {
        }
    }
}
