using Microsoft.EntityFrameworkCore;
using Policy.Data.Models;
using Policy.Helper;
using Policy.Repo;

namespace Policy.Data.Services
{
    public interface IPolicyService
    {
        Task<List<PolicyOutputModelSimple>?> ByNames(string[] policyNames);
        Task<PolicyOutputModelDetailed> GetById(int Id); 
    }
    public class PolicyService : IPolicyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PolicyService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<List<PolicyOutputModelSimple>?> ByNames(string[] policyNames)
        {
            return await (await _unitOfWork.PolicyRepo.FindByCondition(policy=> policyNames.Contains(policy.Name))).MapTo<PolicyOutputModelSimple>().ToListAsync();
        }

        public async Task<PolicyOutputModelDetailed> GetById(int Id)
        {
            return (await _unitOfWork.PolicyRepo.FindById(Id)).MapTo<PolicyOutputModelDetailed>();
        }
    }
}
