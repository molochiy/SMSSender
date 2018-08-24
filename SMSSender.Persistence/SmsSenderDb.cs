using System.Configuration;
using System.Data.Entity;
using SMSSender.Persistence.Entities;
using SMSSender.Persistence.EntityConfigurations;

namespace SMSSender.Persistence
{
    public class SmsSenderDb: DbContext, ISmsSenderDb
    {
        private const string SmsSenderDbName = "SmsSenderDb";

        public SmsSenderDb() : base(ConfigurationManager.ConnectionStrings[SmsSenderDbName].ConnectionString)
        {
        }

        public SmsSenderDb(string connectionString) : base(connectionString)
        {
        }

        public DbContext DbContext => this;

        public virtual DbSet<UserOrdersEntity> UsersOrders { get; set; }
        public virtual DbSet<MessageEntity> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MessageConfiguration());
            modelBuilder.Configurations.Add(new UserOrdersConfiguration());
        }
    }
}