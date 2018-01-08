namespace GiftHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "CompanyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "CompanyAmount");
        }
    }
}
