using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ApplicationLayer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Azure.Func.CleanArchitecture.WebApi
{
    public class HttpExample
    {
        private readonly ILogger _logger;
        public HttpExample(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpExample>();
        }

        [Function("HttpExample")]
        [Authorize]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req, ClaimsPrincipal claimsPrincipal)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Welcome to Azure Functions!");

            return response;
        }

        [Function("Anonymous")]
        [AllowAnonymous]
        public HttpResponseData Anonymous([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req, ClaimsPrincipal claimsPrincipal)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }

}
