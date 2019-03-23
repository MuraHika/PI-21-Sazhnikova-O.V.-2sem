namespace AbstractSecurityShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDciml : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Technics", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Technics", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
