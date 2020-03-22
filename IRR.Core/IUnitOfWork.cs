using System;

namespace IRR.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
