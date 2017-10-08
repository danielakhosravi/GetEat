namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Neighborhood = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        Latitude = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kitchens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Composition = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ResourantId = c.Int(nullable: false),
                        KitchenId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Restourant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kitchens", t => t.KitchenId, cascadeDelete: true)
                .ForeignKey("dbo.Restourants", t => t.Restourant_Id)
                .Index(t => t.KitchenId)
                .Index(t => t.Restourant_Id);
            
            CreateTable(
                "dbo.Restourants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrganisationId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId, cascadeDelete: true)
                .Index(t => t.OrganisationId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerProfileId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Phone = c.String(),
                        Fax = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.OwnerProfileId, cascadeDelete: true)
                .Index(t => t.OwnerProfileId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(nullable: false),
                        ForeName = c.String(),
                        SurName = c.String(),
                        PicGuidId = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Restourant_Id", "dbo.Restourants");
            DropForeignKey("dbo.Restourants", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Organisations", "OwnerProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Restourants", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Menus", "KitchenId", "dbo.Kitchens");
            DropIndex("dbo.Organisations", new[] { "OwnerProfileId" });
            DropIndex("dbo.Restourants", new[] { "AddressId" });
            DropIndex("dbo.Restourants", new[] { "OrganisationId" });
            DropIndex("dbo.Menus", new[] { "Restourant_Id" });
            DropIndex("dbo.Menus", new[] { "KitchenId" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Organisations");
            DropTable("dbo.Restourants");
            DropTable("dbo.Menus");
            DropTable("dbo.Kitchens");
            DropTable("dbo.Addresses");
        }
    }
}
