
using Microsoft.AspNetCore.Mvc;
using Policy.Data.Entities;
using Policy.Data.Models;
using Policy.Data.Repo;
using Policy.Data.Services;


namespace Policy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        public PolicyController(IPolicyService policyService) 
        {
            _policyService = policyService;
        }
        [HttpGet]
        public async Task<PolicyOutputModelDetailed> GetById(int Id)
        {
            return await _policyService.GetById(Id);
        }
        [HttpPost("ByNames")]
        public async Task<IActionResult> GetByNames( [FromBody]string[] PolicyNames)
        {
            return Ok(await _policyService.ByNames(PolicyNames));
        }
        private string GetErrorMessage(Exception ex)
        {
            if (ex.Message.Contains("See the inner exception for details") && ex.InnerException != null)
            {

                return GetErrorMessage(ex.InnerException);
            }

            return ex.Message;
        }

    }
}