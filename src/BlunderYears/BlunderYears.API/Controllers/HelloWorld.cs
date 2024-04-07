namespace BlunderYears.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Extensions.Logging;

    public class HelloWorld
    {
        private readonly ILogger<HelloWorld> logger;

        public HelloWorld(ILogger<HelloWorld> logger)
        {
            this.logger = logger;
        }

        [Function(nameof(HelloWorld))]
        public async Task<IActionResult> HelloWorld1([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            return new OkObjectResult("Hello World!");
        }

        [Function(nameof(HelloWorld2))]
        public async Task<IActionResult> HelloWorld2([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            return new OkObjectResult("Hello World 2!");
        }

        [Function(nameof(HelloWorld3))]
        public async Task<IActionResult> HelloWorld3([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            return new OkObjectResult("Hello World 3!");
        }
    }
}
