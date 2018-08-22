using System.Data.Entity.ModelConfiguration;
using SMSSender.Persistence.Entities;

namespace SMSSender.Persistence.EntityConfigurations
{
    public class UserOrdersConfiguration : EntityTypeConfiguration<UserOrdersEntity>
    {
        public UserOrdersConfiguration()
        {
            this.ToTable("UsersOrders");

            this.Property(r => r.UserMobileNumber).HasMaxLength(10);
        }
    }
}
