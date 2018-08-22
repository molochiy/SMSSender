using System.Data.Entity.ModelConfiguration;
using SMSSender.Persistence.Entities;

namespace SMSSender.Persistence.EntityConfigurations
{
    public class MessageConfiguration : EntityTypeConfiguration<MessageEntity>
    {
        public MessageConfiguration()
        {
            this.ToTable("Messages");

            this.Property(r => r.From).HasMaxLength(10);
            this.Property(r => r.To).HasMaxLength(10);
        }
    }
}
