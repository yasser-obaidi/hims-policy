using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Schema;
using Policy.Data.Entities;
using System.Linq.Expressions;
namespace Policy.Data.Repo
{
    public interface IPolicyRepo
    {
        Task<Entities.Policy> FindById(int id);
        Task<IQueryable<Entities.Policy>> FindByCondition(Expression<Func<Entities.Policy, bool>> expression);
        void Add(Entities.Policy entity);
        void AddRange(IEnumerable<Entities.Policy> entity);
        void DeleteRange(IEnumerable<Entities.Policy> entity);
    }
    public class PolicyRepo : IPolicyRepo
    {
        private readonly Context _db;
        public PolicyRepo(Context context) 
        {
                _db = context;
        }
        public async Task<Entities.Policy> FindById(int id)
        {
            return await _db.Policies.FindAsync(id);
        }
        public async Task<IQueryable<Entities.Policy>> FindByCondition(Expression<Func<Entities.Policy, bool>> expression)
        {
            return _db.Policies.Where(expression).OrderByDescending(t => t.CreatedAt);

        }
        public void Add(Entities.Policy entity)
        {
            _db.Policies.Add(entity);
        }
        public void AddRange(IEnumerable<Entities.Policy> entity)
        {
            _db.Policies.AddRange(entity);
        }
        public void Delete(Entities.Policy entity)
        {

            _db.Policies.Remove(entity);
        }
        public void DeleteRange(IEnumerable<Entities.Policy> entity)
        {
            _db.Policies.RemoveRange(entity);
        }
    }
}
