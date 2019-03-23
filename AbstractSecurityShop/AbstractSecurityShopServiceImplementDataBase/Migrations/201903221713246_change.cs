namespace AbstractSecurityShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TechnicsEquipments", "EquipmentName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TechnicsEquipments", "EquipmentName", c => c.String(nullable: false));
        }
    }
}
