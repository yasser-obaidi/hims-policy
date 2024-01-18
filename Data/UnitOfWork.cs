using System;
using Policy.Data;
using Policy.Data.Entities;
using Policy.Data.Repo;
using Policy.Data.Services;

namespace Policy.Repo
{
    public interface IUnitOfWork
    {
        public IPolicyRepo PolicyRepo {get;}
        public IPlanRepo PlanRepo {get;}
        public IBenefitRepo BenefitRepo {get;}
        public ICategoryRepo CategoryRepo { get;}
        public IUserManagement UserManagement { get; }

        void Dispose();
        Task<int> SaveChangesAsync();

    }
    public class UnitOfWork : IUnitOfWork
    {
        private Context _db ;
        public IPolicyRepo PolicyRepo { get; }
        public IPlanRepo PlanRepo { get; }

        public IBenefitRepo BenefitRepo { get; }

        public ICategoryRepo CategoryRepo { get; }
        public IUserManagement UserManagement { get; }

        public UnitOfWork(Context context,IUserManagement userManagement)
        {
            _db = context;
            PolicyRepo = new PolicyRepo(context);
            PlanRepo = new PlanRepo(context);
            BenefitRepo = new BenefitRepo(context);
            CategoryRepo = new CategoryRepo(context);
            UserManagement = userManagement;

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