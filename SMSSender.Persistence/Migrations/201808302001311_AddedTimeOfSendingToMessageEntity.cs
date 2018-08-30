using System.Data.Entity.Migrations;

namespace SMSSender.Persistence.Migrations
{
    public partial class AddedTimeOfSendingToMessageEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "TimeOfSending", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "TimeOfSending");
        }
    }
}
