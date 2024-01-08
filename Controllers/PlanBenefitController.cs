using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Policy.Data.Models;
using Policy.Data.Services;

namespace Policy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanBenefitController : ControllerBase
    {
        private readonly IPlanBenefitService _planBenefitService;
        public PlanBenefitController(IPlanBenefitService policyService)
        {
            _planBenefitService = policyService;
        }
        [HttpPost("Plan")]
        public async Task<IActionResult> PostPlan(PlanInputModel model)
        {
            try
            {
                await _planBenefitService.AddPlanAsync(model);
               return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(GetErrorMessage(ex));
            }
        }
        [HttpPost("CopyExistPlan")]
        public async Task<IActionResult> CopyExistPlan(PlanCopyExistModel model)
        {
            try
            {
                
                return Ok(await _planBenefitService.CopyExistPlan(model));
            }
            catch (Exception ex)
            {
                return BadRequest(GetErrorMessage(ex));
            }
        }
        [HttpPost("BenefitType")]
        public async Task<IActionResult> PostBenefitType(BenefitTypeInputModel model)
        {
            try
            {
                await _planBenefitService.AddBenefitType(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(GetErrorMessage(ex));
            }
        }
        [HttpPost("BenefitRule")]
        public async Task<IActionResult> PostBenefitRule(BenefitRuleInputModel model)
        {
            try
            {
                await _planBenefitService.AddBenefitRule(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(GetErrorMessage(ex));
            }
        }
        [HttpPost("Category")]
        public async Task<IActionResult> PostCategory(CategoryInputModel model)
        {
            try
            {
                await _planBenefitService.AddCategory(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(GetErrorMessage(ex));
            }
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
