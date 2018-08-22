using System;

namespace SMSSender.Persistence
{
    public class SmsSenderDbProvider : IDbProvider<ISmsSenderDb>
    {
        public SmsSenderDbProvider()
        {
            Db = new SmsSenderDb();
        }

        ~SmsSenderDbProvider()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        protected SmsSenderDb Db { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual ISmsSenderDb Get()
        {
            return Db;
        }

        public virtual void RenewContext()
        {
            Db?.Dispose();
            Db = new SmsSenderDb();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db?.Dispose();
                Db = default(SmsSenderDb);
            }
        }
    }
}