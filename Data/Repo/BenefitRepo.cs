using Microsoft.EntityFrameworkCore;
using Policy.Data.Entities;
using System.Linq.Expressions;

namespace Policy.Data.Repo
{
    public interface IBenefitRepo
    {
        void AddBenefitRule(BenefitRule benefitRule);
        void AddBenefitType(BenefitType benefitType);
        Task<Benefit> FindById(int id);
        Task<IQueryable<Plan>> FindByCondition(Expression<Func<Plan, bool>> expression);
        void RemoveBenefit(Benefit benefit);
    }
    public class BenefitRepo : IBenefitRepo
    {
        private readonly Context _db;
        public BenefitRepo(Context db)
        {
            _db = db;
        }
        public async Task<Benefit> FindById(int id)
        {
            return await _db.Benefits.FindAsync(id);
        }
        public async Task<IQueryable<Plan>> FindByCondition(Expression<Func<Plan, bool>> expression)
        {
            return _db.Plans.Where(expression).OrderByDescending(t => t.CreatedAt).Include(x => x.Benefits);

        }
        public void AddBenefitRule(BenefitRule benefitRule)
        {
           _db.BenefitRules.Add(benefitRule);
        }

        public void AddBenefitType(BenefitType benefitType)
        {
            _db.BenefitTypes.Add(benefitType);
        }

        public void RemoveBenefit(Benefit benefit)
        {
            _db.Benefits.Remove(benefit);
        }
    }
}
