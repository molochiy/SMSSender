using System.Data.Entity.Migrations;

namespace SMSSender.Persistence.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        From = c.String(maxLength: 10),
                        To = c.String(maxLength: 10),
                        Message = c.String(),
                        Status = c.Int(nullable: false),
                        ExternalMessageId = c.String(),
                        CreatedUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersOrders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserMobileNumber = c.String(maxLength: 10),
                        OrderDateUtc = c.DateTime(nullable: false),
                        CreatedUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsersOrders");
            DropTable("dbo.Messages");
        }
    }
}
