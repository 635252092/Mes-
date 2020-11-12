namespace Mes.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Pwd = c.String(),
                        Role = c.String(),
                        Dept_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depts", t => t.Dept_Id)
                .Index(t => t.Dept_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emps", "Dept_Id", "dbo.Depts");
            DropIndex("dbo.Emps", new[] { "Dept_Id" });
            DropTable("dbo.Emps");
            DropTable("dbo.Depts");
        }
    }
}
