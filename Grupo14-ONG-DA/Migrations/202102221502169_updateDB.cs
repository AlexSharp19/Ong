namespace Grupo14_ONG_DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ONGpartners", "ONGtype_Id", "dbo.ONGtypes");
            DropForeignKey("dbo.ONGpartners", "Province_Id", "dbo.Provinces");
            DropIndex("dbo.ONGpartners", new[] { "ONGtype_Id" });
            DropIndex("dbo.ONGpartners", new[] { "Province_Id" });
            DropTable("dbo.ONGpartners");
            DropTable("dbo.ONGtypes");
            DropTable("dbo.Provinces");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ONGtypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ONGpartners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ONGpartners", "Province_Id");
            CreateIndex("dbo.ONGpartners", "ONGtype_Id");
            AddForeignKey("dbo.ONGpartners", "Province_Id", "dbo.Provinces", "Id");
            AddForeignKey("dbo.ONGpartners", "ONGtype_Id", "dbo.ONGtypes", "Id");
        }
    }
}
