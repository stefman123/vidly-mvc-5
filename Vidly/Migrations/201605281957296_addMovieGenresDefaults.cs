namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieGenresDefaults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "GenresId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenresId");
            AddForeignKey("dbo.Movies", "GenresId", "dbo.MovieGenres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genres");

            Sql("INSERT INTO MovieGenres (Id,Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO MovieGenres (Id,Name) VALUES (2,'Action')");
            Sql("INSERT INTO MovieGenres (Id,Name) VALUES (3,'Family')");
            Sql("INSERT INTO MovieGenres (Id,Name) VALUES (4,'Romance')");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genres", c => c.String());
            DropForeignKey("dbo.Movies", "GenresId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "GenresId" });
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "GenresId");
            DropColumn("dbo.Movies", "DateAdded");
            DropTable("dbo.MovieGenres");
        }
    }
}
