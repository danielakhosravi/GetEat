namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestourantId = c.Int(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                        ReservationDateTime = c.DateTime(nullable: false),
                        NumberOfPeople = c.Int(nullable: false),
                        Request = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Menus", "Booking_Id", c => c.Int());
            CreateIndex("dbo.Menus", "Booking_Id");
            AddForeignKey("dbo.Menus", "Booking_Id", "dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Booking_Id", "dbo.Bookings");
            DropIndex("dbo.Menus", new[] { "Booking_Id" });
            DropColumn("dbo.Menus", "Booking_Id");
            DropTable("dbo.Bookings");
        }
    }
}
