namespace AbstractSecurityShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Sum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Sum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
