using System;

namespace SMSSender.Persistence
{
    public interface IDbProvider<out TIDb> : IDisposable
        where TIDb : ISmsSenderDb
    {
        TIDb Get();

        void RenewContext();
    }
}