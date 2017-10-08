namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Reviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentatorUserProfileId = c.Int(nullable: false),
                        RestourantId = c.Int(nullable: false),
                        Comment = c.String(),
                        Score = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.CommentatorUserProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Restourants", t => t.RestourantId)
                .Index(t => t.CommentatorUserProfileId)
                .Index(t => t.RestourantId);
            
            AddColumn("dbo.Restourants", "PicGuidId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "RestourantId", "dbo.Restourants");
            DropForeignKey("dbo.Reviews", "CommentatorUserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Reviews", new[] { "RestourantId" });
            DropIndex("dbo.Reviews", new[] { "CommentatorUserProfileId" });
            DropColumn("dbo.Restourants", "PicGuidId");
            DropTable("dbo.Reviews");
        }
    }
}
