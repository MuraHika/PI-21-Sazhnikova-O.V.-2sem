namespace AbstractSecurityShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "WorkerId", c => c.Int());
            CreateIndex("dbo.Orders", "WorkerId");
            AddForeignKey("dbo.Orders", "WorkerId", "dbo.Workers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "WorkerId", "dbo.Workers");
            DropIndex("dbo.Orders", new[] { "WorkerId" });
            DropColumn("dbo.Orders", "WorkerId");
            DropTable("dbo.Workers");
        }
    }
}
