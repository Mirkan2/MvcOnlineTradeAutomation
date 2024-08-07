namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class2",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        deneme = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AlterColumn("dbo.Departmen", "DepartmanAd", c => c.String(maxLength: 25, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departmen", "DepartmanAd", c => c.String(maxLength: 30, unicode: false));
            DropTable("dbo.Class2");
        }
    }
}
