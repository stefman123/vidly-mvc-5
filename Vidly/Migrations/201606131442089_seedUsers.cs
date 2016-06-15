namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                    VALUES(N'4e6d8f77-ad65-4c4f-aa9e-4c08c3d26f24', N'admin@vidly.com', 0, N'AMOSzzvIaQqYp6di9XnmQNRTSTfU1wbZ0t1aqlfkdDmG6xiy4POTml92WSduApIOew==', N'5928ca12-5cc3-41ad-97fa-5e3bc0bae9bf', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                    VALUES(N'ae48b7a3-5227-4ae5-89b4-bc8e2ed1de17', N'guest@vidly.com', 0, N'AMQZgYqKu0YUSeHlCwWJ9iZC6BqwXU+k7GpKVQD6JKjoM+IUpXWwUwP7t/mgUOv3Sg==', N'565ed254-0b40-4d64-bbdb-3bae124213e1', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) 
                    VALUES (N'e621d919-f647-4d3f-abe2-299f77ba8552', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) 
                    VALUES (N'4e6d8f77-ad65-4c4f-aa9e-4c08c3d26f24', N'e621d919-f647-4d3f-abe2-299f77ba8552')
                ");
        }

    public override void Down()
        {
        }
    }
}
