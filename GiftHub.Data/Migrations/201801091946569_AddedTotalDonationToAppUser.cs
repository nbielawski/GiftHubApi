namespace GiftHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTotalDonationToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "TotalDonation", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "TotalDonation");
        }
    }
}
