namespace Musicland.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Genre = c.String(),
                        Musician_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Musicians", t => t.Musician_Id)
                .Index(t => t.Musician_Id);
            
            CreateTable(
                "dbo.Musicians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Date = c.DateTime(nullable: false),
                        Tickets = c.Int(nullable: false),
                        Album_Id = c.Int(),
                        Musician_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .ForeignKey("dbo.Musicians", t => t.Musician_Id)
                .Index(t => t.Album_Id)
                .Index(t => t.Musician_Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Duration = c.Int(nullable: false),
                        Album_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Concerts", "Musician_Id", "dbo.Musicians");
            DropForeignKey("dbo.Concerts", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Musician_Id", "dbo.Musicians");
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropIndex("dbo.Concerts", new[] { "Musician_Id" });
            DropIndex("dbo.Concerts", new[] { "Album_Id" });
            DropIndex("dbo.Albums", new[] { "Musician_Id" });
            DropTable("dbo.Songs");
            DropTable("dbo.Concerts");
            DropTable("dbo.Musicians");
            DropTable("dbo.Albums");
        }
    }
}
