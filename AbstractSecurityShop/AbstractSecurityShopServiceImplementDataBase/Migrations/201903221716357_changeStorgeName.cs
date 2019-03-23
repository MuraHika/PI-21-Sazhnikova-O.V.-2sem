namespace AbstractSecurityShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStorgeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Storages", "StorageName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Storages", "StorageName", c => c.String(nullable: false));
        }
    }
}
