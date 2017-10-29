namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RestourantId = c.Int(nullable: false),
                        Description = c.String(),
                        EventDateTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restourants", t => t.RestourantId, cascadeDelete: true)
                .Index(t => t.RestourantId);
            
            AddColumn("dbo.Restourants", "Description", c => c.String());
            AddColumn("dbo.Restourants", "PhoneNumber", c => c.String());
            AddColumn("dbo.Restourants", "WebSite", c => c.String());
            AddColumn("dbo.Restourants", "KitchenId", c => c.Int(nullable: false));
            AddColumn("dbo.Organisations", "About", c => c.String());
            AddColumn("dbo.Organisations", "WebSite", c => c.String());
            AddColumn("dbo.Organisations", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Organisations", "RegistrationNumber", c => c.String());
            AddColumn("dbo.UserProfiles", "PhoneNumber", c => c.String());
            CreateIndex("dbo.Restourants", "KitchenId");
            CreateIndex("dbo.Organisations", "AddressId");
            AddForeignKey("dbo.Restourants", "KitchenId", "dbo.Kitchens", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Organisations", "AddressId", "dbo.Addresses", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organisations", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Restourants", "KitchenId", "dbo.Kitchens");
            DropForeignKey("dbo.Events", "RestourantId", "dbo.Restourants");
            DropIndex("dbo.Organisations", new[] { "AddressId" });
            DropIndex("dbo.Restourants", new[] { "KitchenId" });
            DropIndex("dbo.Events", new[] { "RestourantId" });
            DropColumn("dbo.UserProfiles", "PhoneNumber");
            DropColumn("dbo.Organisations", "RegistrationNumber");
            DropColumn("dbo.Organisations", "AddressId");
            DropColumn("dbo.Organisations", "WebSite");
            DropColumn("dbo.Organisations", "About");
            DropColumn("dbo.Restourants", "KitchenId");
            DropColumn("dbo.Restourants", "WebSite");
            DropColumn("dbo.Restourants", "PhoneNumber");
            DropColumn("dbo.Restourants", "Description");
            DropTable("dbo.Events");
        }
    }
}
