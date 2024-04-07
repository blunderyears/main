namespace BlunderYears.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Extensions.Logging;

    public class Function1
    {
        private readonly ILogger<Function1> logger;

        public Function1(ILogger<Function1> logger)
        {
            this.logger = logger;
        }

        [Function("Function1")]
        public async Task<IActionResult> HelloWorld([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            return new OkObjectResult("Hello World!");
        }
    }
}
