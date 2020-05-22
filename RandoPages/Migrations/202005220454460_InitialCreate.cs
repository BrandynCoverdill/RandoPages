namespace RandoPages.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlashCards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        CardType = c.String(nullable: false),
                        Question = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlashCards");
        }
    }
}
