using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Resources;

namespace Policy.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        // to be removed later 
        private readonly string deleteException = "The DELETE statement conflicted with the REFERENCE constraint";

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public int getStatusCode(Exception ex)
        {
            if (ex?.InnerException?.Message?.Contains(deleteException) == true) return (int)HttpStatusCode.BadRequest;//add a general error object to throw with stat code and assignee it here
            return (int)HttpStatusCode.InternalServerError;
        }
        private string GetErrorMessage(Exception ex)
        {
            if (ex.Message.Contains("See the inner exception for details") && ex.InnerException != null)
            {

                return GetErrorMessage(ex.InnerException);
            }

            return ex.Message;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception) //SystemError
            {
                _logger.LogError(exception, exception.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = getStatusCode(exception); // set the status code dynamicly 
                var msg = GetErrorMessage(exception);
                var response = new response() { StatusCode = context.Response.StatusCode,
                    Message = msg,
                    Details = exception.StackTrace?.ToString(),
                    Status = GetStatus(context.Response.StatusCode.ToString())

                };


                //var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                //var json_reponse =  JsonSerializer.Serialize(response, options);

                var options = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                };
                var json_reponse = JsonConvert.SerializeObject(response, Formatting.Indented, options);




                await context.Response.WriteAsync(json_reponse);
            }

        }
        public string GetStatus(string statusCode)
        {
            if (statusCode.ElementAtOrDefault(0) == '4')
                return "error";
            if (statusCode.ElementAtOrDefault(0) == '2')
                return "Warning";
            else
                return "fail";
        }
        public class response {
            public string? Status { get; set; }

            public int StatusCode { get; set; }

            public string? Message { get; set; }

            public string? Details { get; set; }
        }

    }
}
