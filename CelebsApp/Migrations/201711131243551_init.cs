namespace CelebsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Celebs",
                c => new
                    {
                        CelebId = c.Int(nullable: false, identity: true),
                        CelebName = c.String(),
                        CelebAge = c.Int(nullable: false),
                        CelebCountry = c.String(),
                    })
                .PrimaryKey(t => t.CelebId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Celebs");
        }
    }
}
