﻿namespace MousePark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class June8Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        AreaName = c.String(nullable: false, maxLength: 100),
                        ParkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaId)
                .ForeignKey("dbo.Park", t => t.ParkId, cascadeDelete: true)
                .Index(t => t.ParkId);
            
            CreateTable(
                "dbo.Park",
                c => new
                    {
                        ParkId = c.Int(nullable: false, identity: true),
                        ParkName = c.String(nullable: false),
                        AdmissionPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ParkId);
            
            CreateTable(
                "dbo.Eatery",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CuisineType = c.String(nullable: false),
                        DineIn = c.Boolean(nullable: false),
                        Tier = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        ParkId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Area", t => t.AreaId, cascadeDelete: false)
                .ForeignKey("dbo.Park", t => t.ParkId, cascadeDelete: false)
                .Index(t => t.ParkId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Ride",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RideDescription = c.String(nullable: false),
                        HeightReq = c.Int(nullable: false),
                        RideType = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        ParkId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Area", t => t.AreaId, cascadeDelete: false)
                .ForeignKey("dbo.Park", t => t.ParkId, cascadeDelete: false)
                .Index(t => t.ParkId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TargetAge = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        RunTime = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        ParkId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Area", t => t.AreaId, cascadeDelete: false)
                .ForeignKey("dbo.Park", t => t.ParkId, cascadeDelete: false)
                .Index(t => t.ParkId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Show", "ParkId", "dbo.Park");
            DropForeignKey("dbo.Show", "AreaId", "dbo.Area");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Ride", "ParkId", "dbo.Park");
            DropForeignKey("dbo.Ride", "AreaId", "dbo.Area");
            DropForeignKey("dbo.Eatery", "ParkId", "dbo.Park");
            DropForeignKey("dbo.Eatery", "AreaId", "dbo.Area");
            DropForeignKey("dbo.Area", "ParkId", "dbo.Park");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Show", new[] { "AreaId" });
            DropIndex("dbo.Show", new[] { "ParkId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Ride", new[] { "AreaId" });
            DropIndex("dbo.Ride", new[] { "ParkId" });
            DropIndex("dbo.Eatery", new[] { "AreaId" });
            DropIndex("dbo.Eatery", new[] { "ParkId" });
            DropIndex("dbo.Area", new[] { "ParkId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Show");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Ride");
            DropTable("dbo.Eatery");
            DropTable("dbo.Park");
            DropTable("dbo.Area");
        }
    }
}
