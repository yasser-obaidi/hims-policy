using System;
using Policy.Data;
using Policy.Data.Entities;

namespace Policy.Repo
{
    public class UnitOfWork : IDisposable
    {
        private Context _db ;
        public UnitOfWork(Context context)
        {
            _db = context;
        }
        public async Task<int> SaveChangesAsync()
        {
           return await _db.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}