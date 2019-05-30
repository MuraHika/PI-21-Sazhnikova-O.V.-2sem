namespace AbstractSecurityShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        TechnicsId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Technics", t => t.TechnicsId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TechnicsId);
            
            CreateTable(
                "dbo.Technics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TechnicsName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TechnicsEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TechnicsId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        EquipmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.Technics", t => t.TechnicsId, cascadeDelete: true)
                .Index(t => t.TechnicsId)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StorageEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechnicsEquipments", "TechnicsId", "dbo.Technics");
            DropForeignKey("dbo.TechnicsEquipments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.StorageEquipments", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.StorageEquipments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Orders", "TechnicsId", "dbo.Technics");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.StorageEquipments", new[] { "EquipmentId" });
            DropIndex("dbo.StorageEquipments", new[] { "StorageId" });
            DropIndex("dbo.TechnicsEquipments", new[] { "EquipmentId" });
            DropIndex("dbo.TechnicsEquipments", new[] { "TechnicsId" });
            DropIndex("dbo.Orders", new[] { "TechnicsId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Storages");
            DropTable("dbo.StorageEquipments");
            DropTable("dbo.Equipments");
            DropTable("dbo.TechnicsEquipments");
            DropTable("dbo.Technics");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
