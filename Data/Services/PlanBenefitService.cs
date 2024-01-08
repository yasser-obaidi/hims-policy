﻿using Microsoft.EntityFrameworkCore;
using Policy.Data.Entities;
using Policy.Data.Enums;
using Policy.Data.Models;
using Policy.Helper;
using Policy.Repo;

namespace Policy.Data.Services
{
    public interface IPlanBenefitService
    {
        Task<IList<PlanOutputModelSimple>> GetPlanAll();

        Task<PlanOutputModelDetailed> GetPlanById(int Id);

        Task<IList<PlanOutputModelSimple>> GetPlanByIds(int[] planIds);

        Task<IList<BenefitOutputModelSimple>> GetPlanBenefitsByPlanId(int planId);

        Task<BenefitOutputModelSimple> GetBenefitById(int planBenefitId);

        Task<PlanOutputModelSimple> CopyExistPlan(PlanCopyExistModel Id);

        Task AddPlanAsync(PlanInputModel Model);

        Task UpdatePlan(PlanInputModel model);

        Task InsertBenefit(InsertBenefitToPlanModel Model);

        Task UpdateBenefit(BenefitUpdateModel model);

        Task DeleteBenefit(int Id);
        Task AddCategory(CategoryInputModel model);
        Task AddBenefitType(BenefitTypeInputModel model);
        Task AddBenefitRule(BenefitRuleInputModel model);
    }
    public class PlanBenefitService : IPlanBenefitService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlanBenefitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddBenefitRule(BenefitRuleInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || model.LimitType == null || model.LimitType == LimitType.None )
            {
                throw new Exception("check input");
            }
            _unitOfWork.BenefitRepo.AddBenefitRule(model.MapTo<BenefitRule>());
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddBenefitType(BenefitTypeInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) )
            {
                throw new Exception("check input");
            }
            _unitOfWork.BenefitRepo.AddBenefitType(model.MapTo<BenefitType>());
            await _unitOfWork.SaveChangesAsync() ;
        }

        public async Task AddCategory(CategoryInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new Exception("check input");
            }
            _unitOfWork.CategoryRepo.Add(model.MapTo<Category>());
            await _unitOfWork.SaveChangesAsync() ;
        }

        public async Task AddPlanAsync(PlanInputModel Model)
        {
            if (string.IsNullOrWhiteSpace(Model.Name) || Model.CoverageLimit == null || string.IsNullOrWhiteSpace(Model.CoverageRegion) || string.IsNullOrWhiteSpace(Model.CurrencyCode) || string.IsNullOrWhiteSpace(Model.AlternativeName) || Model.IsActive == null )
            {
                throw new Exception("check input");
            }
            _unitOfWork.PlanRepo.Add(Model.MapTo<Plan>());
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PlanOutputModelSimple> CopyExistPlan(PlanCopyExistModel model)
        {
            if (model.ExistingPlanId == null || model.Name == null)
            {
                throw new Exception("check input");


            }
            var plan = await (await _unitOfWork.PlanRepo.FindByCondition(plan=>plan.Id == model.ExistingPlanId)).AsNoTracking().FirstOrDefaultAsync();
            if (plan == null)
            {
                throw new Exception("no plan was found");
            }
            plan.Name = model.Name;
            plan.AlternativeName = model.Name;
            plan.Id = null;
            if (plan.Benefits != null)
            {
                foreach (var Benefit in plan.Benefits)
                {
                    Benefit.Id = null;
                    Benefit.PlanId = null;
                }
            }
            
            _unitOfWork.PlanRepo.Add(plan);
            await _unitOfWork.SaveChangesAsync();
            return plan.MapTo<PlanOutputModelSimple>(); 
        }

        public async Task DeleteBenefit(int Id)
        {
            var Benefit =  await _unitOfWork.BenefitRepo.FindById(Id);
            if (Benefit == null)
            {
                throw new Exception("not found");
            }
            _unitOfWork.BenefitRepo.RemoveBenefit(Benefit);
            await _unitOfWork.SaveChangesAsync();   
        }

        public async Task<BenefitOutputModelSimple> GetBenefitById(int Id)
        {
            return (await _unitOfWork.BenefitRepo.FindById(Id)).MapTo<BenefitOutputModelSimple>();  
        }

        public Task<IList<PlanOutputModelSimple>> GetPlanAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BenefitOutputModelSimple>?> GetPlanBenefitsByPlanId(int planId)
        {
             return ( await (await _unitOfWork.PlanRepo.FindByCondition(plan=>plan.Id == planId)).FirstOrDefaultAsync())?.Benefits?.MapTo<List<BenefitOutputModelSimple>>();
        }

        public Task<PlanOutputModelDetailed> GetPlanById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<PlanOutputModelSimple>> GetPlanByIds(int[] planIds)
        {
            throw new NotImplementedException();
        }

        public Task InsertBenefit(InsertBenefitToPlanModel Model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBenefit(BenefitUpdateModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlan(PlanInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}