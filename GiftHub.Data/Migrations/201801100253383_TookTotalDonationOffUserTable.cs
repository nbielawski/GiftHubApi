namespace GiftHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TookTotalDonationOffUserTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "TotalDonation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "TotalDonation", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
