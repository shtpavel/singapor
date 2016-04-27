namespace Singapor.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Address = c.String(),
                        Phone = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(nullable: false, maxLength: 50),
                        IsContainer = c.Boolean(nullable: false),
                        TypeId = c.Guid(),
                        ParentUnitId = c.Guid(),
                        CompanyId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.ParentUnitId)
                .ForeignKey("dbo.UnitType", t => t.TypeId)
                .Index(t => t.TypeId)
                .Index(t => t.ParentUnitId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.UnitType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IsContainer = c.Boolean(nullable: false),
                        IsUtilityProvider = c.Boolean(nullable: false),
                        TimeIntervalUnit = c.Int(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        CompanyId = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utility",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CompanyId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utility", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.User");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.User", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Unit", "TypeId", "dbo.UnitType");
            DropForeignKey("dbo.UnitType", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Unit", "ParentUnitId", "dbo.Unit");
            DropForeignKey("dbo.Unit", "CompanyId", "dbo.Company");
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropIndex("dbo.Utility", new[] { "CompanyId" });
            DropIndex("dbo.User", new[] { "CompanyId" });
            DropIndex("dbo.UnitType", new[] { "CompanyId" });
            DropIndex("dbo.Unit", new[] { "CompanyId" });
            DropIndex("dbo.Unit", new[] { "ParentUnitId" });
            DropIndex("dbo.Unit", new[] { "TypeId" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Utility");
            DropTable("dbo.Roles");
            DropTable("dbo.User");
            DropTable("dbo.UnitType");
            DropTable("dbo.Unit");
            DropTable("dbo.Company");
        }
    }
}
