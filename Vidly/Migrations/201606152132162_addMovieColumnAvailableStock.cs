namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieColumnAvailableStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableStock");
        }
    }
}
