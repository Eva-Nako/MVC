namespace SPORT_STORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detaje_Porosi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sasia = c.Int(nullable: false),
                        PorosiID = c.Int(nullable: false),
                        ProduktID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Porosis", t => t.PorosiID, cascadeDelete: true)
                .ForeignKey("dbo.Produkts", t => t.ProduktID, cascadeDelete: true)
                .Index(t => t.PorosiID)
                .Index(t => t.ProduktID);
            
            CreateTable(
                "dbo.Porosis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sasia = c.Int(nullable: false),
                        Adresa = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Emri = c.String(nullable: false),
                        Mbiemri = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        NrTelefon = c.String(nullable: false),
                        Tipi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Emri = c.String(nullable: false, maxLength: 50),
                        Pershkrimi = c.String(nullable: false, maxLength: 50),
                        Cmimi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        imazh = c.String(),
                        KategoriID = c.Int(),
                        InventarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventars", t => t.InventarID, cascadeDelete: true)
                .ForeignKey("dbo.Kategoris", t => t.KategoriID)
                .Index(t => t.KategoriID)
                .Index(t => t.InventarID);
            
            CreateTable(
                "dbo.Inventars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sasia = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emri = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shportas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sasia = c.Int(nullable: false),
                        ProduktID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Produkts", t => t.ProduktID)
                .Index(t => t.ProduktID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detaje_Porosi", "ProduktID", "dbo.Produkts");
            DropForeignKey("dbo.Shportas", "ProduktID", "dbo.Produkts");
            DropForeignKey("dbo.Produkts", "KategoriID", "dbo.Kategoris");
            DropForeignKey("dbo.Produkts", "InventarID", "dbo.Inventars");
            DropForeignKey("dbo.Porosis", "UserId", "dbo.Users");
            DropForeignKey("dbo.Detaje_Porosi", "PorosiID", "dbo.Porosis");
            DropIndex("dbo.Shportas", new[] { "ProduktID" });
            DropIndex("dbo.Produkts", new[] { "InventarID" });
            DropIndex("dbo.Produkts", new[] { "KategoriID" });
            DropIndex("dbo.Porosis", new[] { "UserId" });
            DropIndex("dbo.Detaje_Porosi", new[] { "ProduktID" });
            DropIndex("dbo.Detaje_Porosi", new[] { "PorosiID" });
            DropTable("dbo.Shportas");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Inventars");
            DropTable("dbo.Produkts");
            DropTable("dbo.Users");
            DropTable("dbo.Porosis");
            DropTable("dbo.Detaje_Porosi");
        }
    }
}
