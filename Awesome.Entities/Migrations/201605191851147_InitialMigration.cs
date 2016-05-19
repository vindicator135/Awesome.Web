namespace Awesome.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        PostId = c.Int(nullable: false),
                        AvatarUrl = c.String(),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        UserWebSite = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        CreatedBy_Id = c.String(maxLength: 128),
                        LastUpdatedBy_Id = c.String(maxLength: 128),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LastUpdatedBy_Id)
                .ForeignKey("dbo.Comments", t => t.ParentId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.CommentNode",
                c => new
                    {
                        AncestorId = c.Int(nullable: false),
                        OffspringId = c.Int(nullable: false),
                        Separation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AncestorId, t.OffspringId })
                .ForeignKey("dbo.Comments", t => t.OffspringId)
                .ForeignKey("dbo.Comments", t => t.AncestorId)
                .Index(t => t.AncestorId)
                .Index(t => t.OffspringId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AvatarUrl = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        SubContent = c.String(),
                        SubTitle = c.String(),
                        PreContent = c.String(),
                        PostAvatarUrl = c.String(),
                        Title = c.String(),
                        TitleText = c.String(),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        CreatedBy_Id = c.String(maxLength: 128),
                        LastUpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LastUpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Guid(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                        Post_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Post_PostId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        CreatedBy_Id = c.String(maxLength: 128),
                        LastUpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LastUpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PostTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Tags", "LastUpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tags", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Ratings", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "LastUpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "ParentId", "dbo.Comments");
            DropForeignKey("dbo.CommentNode", "AncestorId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "LastUpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentNode", "OffspringId", "dbo.Comments");
            DropIndex("dbo.PostTags", new[] { "TagId" });
            DropIndex("dbo.PostTags", new[] { "PostId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tags", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Tags", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Ratings", new[] { "Post_PostId" });
            DropIndex("dbo.Ratings", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Posts", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Posts", new[] { "CreatedBy_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CommentNode", new[] { "OffspringId" });
            DropIndex("dbo.CommentNode", new[] { "AncestorId" });
            DropIndex("dbo.Comments", new[] { "ParentId" });
            DropIndex("dbo.Comments", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Comments", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.PostTags");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tags");
            DropTable("dbo.Ratings");
            DropTable("dbo.Posts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CommentNode");
            DropTable("dbo.Comments");
        }
    }
}
