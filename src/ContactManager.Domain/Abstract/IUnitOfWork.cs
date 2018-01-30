using ContactManager.Domain.Entitites;
using System;

namespace ContactManager.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> People { get; }
        IRepository<Address> Addresses { get; }
    }
}
