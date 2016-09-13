namespace Singapor.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CompanyId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project", "CompanyId", "dbo.Company");
            DropIndex("dbo.Project", new[] { "CompanyId" });
            DropTable("dbo.Project");
        }
    }
}
