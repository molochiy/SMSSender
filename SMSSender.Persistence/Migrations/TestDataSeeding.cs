using System;
using System.Collections.Generic;
using SMSSender.Persistence.Entities;

namespace SMSSender.Persistence.Migrations
{
    public class TestDataSeeding
    {
        public static void SeedDemoUsers(SmsSenderDb context)
        {
            context.UsersOrders.AddRange(new List<UserOrdersEntity>
            {
                new UserOrdersEntity
                {
                    UserMobileNumber = "0123456789",
                    OrderDateUtc = new DateTime(2018, 8, 24)
                },
                new UserOrdersEntity
                {
                    UserMobileNumber = "0951236874",
                    OrderDateUtc = new DateTime(2018, 8, 20)
                },
                new UserOrdersEntity
                {
                    UserMobileNumber = "0741478523",
                    OrderDateUtc = new DateTime(2018, 8, 15)
                },
                new UserOrdersEntity
                {
                    UserMobileNumber = "0953687421",
                    OrderDateUtc = new DateTime(2018, 7, 11)
                },
                new UserOrdersEntity
                {
                    UserMobileNumber = "0123456789",
                    OrderDateUtc = new DateTime(2018, 6, 3)
                }
            });

            context.SaveChanges();
        }
    }
}
