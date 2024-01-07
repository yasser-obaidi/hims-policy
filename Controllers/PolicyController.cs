
using Microsoft.AspNetCore.Mvc;


namespace Policy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        
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