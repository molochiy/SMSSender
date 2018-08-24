using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace SMSSender.Persistence.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SmsSenderDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            this.SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(SmsSenderDb context)
        {
            TestDataSeeding.SeedDemoUsers(context);
        }

        private class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
        {
            protected override void Generate(AddColumnOperation addColumnOperation)
            {
                SetCreatedUtcColumn(addColumnOperation.Column);

                base.Generate(addColumnOperation);
            }

            protected override void Generate(CreateTableOperation createTableOperation)
            {
                foreach (ColumnModel columnModel in createTableOperation.Columns)
                {
                    SetCreatedUtcColumn(columnModel);
                }

                base.Generate(createTableOperation);
            }

            private static void SetCreatedUtcColumn(PropertyModel column)
            {
                if (column.Name == "CreatedUtc")
                {
                    column.DefaultValueSql = "GETUTCDATE()";
                }
            }
        }
    }
}
