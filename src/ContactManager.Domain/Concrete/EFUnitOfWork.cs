using ContactManager.Domain.Abstract;
using ContactManager.Domain.Entitites;
using ContactManager.Domain.DB;

namespace ContactManager.Domain.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ContactContext context;
        private IRepository<Address> addresses;
        private IRepository<Person> people;

        public EFUnitOfWork(ContactContext context)
        {
            this.context = context;
        }

        public IRepository<Address> Addresses
        {
            get
            {
                return addresses ?? (addresses = new EFRepository<Address>(context));
            }
        }

        public IRepository<Person> People
        {
            get
            {
                return people ?? (people = new EFRepository<Person>(context));
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EFUnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
