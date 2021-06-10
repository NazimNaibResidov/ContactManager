using ContactManager.Repostory.Core;
using System;

namespace ContactManager.UnitOf.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepstory<T> Repository<T>() where T : class;

        bool Commit();

        void Rollback();
    }
}