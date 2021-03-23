namespace Grupo14_ONG_DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pablo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 255),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EntityMultimedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        MultiMedia_Id = c.Int(),
                        TypeEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MultiMedias", t => t.MultiMedia_Id)
                .ForeignKey("dbo.TypeEntities", t => t.TypeEntity_Id)
                .Index(t => t.MultiMedia_Id)
                .Index(t => t.TypeEntity_Id);
            
            CreateTable(
                "dbo.MultiMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        TypeFile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ONGpartners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        IdMercadoPago = c.String(nullable: false),
                        ONGtype_Id = c.Int(),
                        Province_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ONGtypes", t => t.ONGtype_Id)
                .ForeignKey("dbo.Provinces", t => t.Province_Id)
                .Index(t => t.ONGtype_Id)
                .Index(t => t.Province_Id);
            
            CreateTable(
                "dbo.ONGtypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 255),
                        Name = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        Rols_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rols", t => t.Rols_Id)
                .Index(t => t.Rols_Id);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemONGs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlLogo = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        WelcomeMessage = c.String(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemONGs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Rols_Id", "dbo.Rols");
            DropForeignKey("dbo.Projects", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ONGpartners", "Province_Id", "dbo.Provinces");
            DropForeignKey("dbo.ONGpartners", "ONGtype_Id", "dbo.ONGtypes");
            DropForeignKey("dbo.EntityMultimedias", "TypeEntity_Id", "dbo.TypeEntities");
            DropForeignKey("dbo.EntityMultimedias", "MultiMedia_Id", "dbo.MultiMedias");
            DropIndex("dbo.SystemONGs", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Rols_Id" });
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropIndex("dbo.ONGpartners", new[] { "Province_Id" });
            DropIndex("dbo.ONGpartners", new[] { "ONGtype_Id" });
            DropIndex("dbo.EntityMultimedias", new[] { "TypeEntity_Id" });
            DropIndex("dbo.EntityMultimedias", new[] { "MultiMedia_Id" });
            DropTable("dbo.SystemONGs");
            DropTable("dbo.Rols");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.Provinces");
            DropTable("dbo.ONGtypes");
            DropTable("dbo.ONGpartners");
            DropTable("dbo.TypeEntities");
            DropTable("dbo.MultiMedias");
            DropTable("dbo.EntityMultimedias");
            DropTable("dbo.ContactForms");
        }
    }
}
