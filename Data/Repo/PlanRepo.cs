using Microsoft.EntityFrameworkCore;
using Policy.Data.Entities;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Policy.Data.Repo
{
    public interface IPlanRepo 
    {
        Task<Plan> FindById(int id);
        Task<IQueryable<Plan >> FindByCondition(Expression<Func<Plan, bool>> expression);
        void Add(Plan entity);
        void AddRange(IEnumerable<Plan> entity);
        void DeleteRange(IEnumerable<Plan> entity);
    }
    public class PlanRepo : IPlanRepo
    {
        private readonly Context _db;
        public PlanRepo(Context db)
        {
            _db = db;
        }
        public async Task<Plan> FindById(int id)
        {
            return await _db.Plans.FindAsync(id);
        }
        public async Task<IQueryable<Plan>> FindByCondition(Expression<Func<Plan, bool>> expression)
        {
            return _db.Plans.Where(expression).OrderByDescending(t => t.CreatedAt).Include(x=>x.Benefits);

        }
        public void Add(Plan entity)
        {

            _db.Plans.Add(entity);
        }
        public void AddRange(IEnumerable<Plan> entity)
        {
            _db.Plans.AddRange(entity);
        }
        public void Delete(Plan entity)
        {

            _db.Plans.Remove(entity);
        }
        public void DeleteRange(IEnumerable<Plan> entity)
        {
            _db.Plans.RemoveRange(entity);
        }
    }
}
