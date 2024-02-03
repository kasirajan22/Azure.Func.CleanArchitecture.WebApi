using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Azure.Func.CleanArchitecture.WebApi
{
    public class HttpExample
    {
        private readonly ILogger _logger;
        private readonly IMyService _myService;

        public HttpExample(ILoggerFactory loggerFactory,IMyService myService)
        {
            _logger = loggerFactory.CreateLogger<HttpExample>();
            _myService = myService;
        }

        [Function("HttpExample")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            _logger.LogInformation(_myService.DoSomething());
            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
