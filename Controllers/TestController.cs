using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnet_essentials
{
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet("test")]
        public async Task<IActionResult> Test([FromServices] ILogger<TestController> logger, CancellationToken token)
        {
            await Task.Delay(5000);
            if (token.IsCancellationRequested)
            {
                logger.LogInformation("Not returning Hello World\n");
                return new ContentResult() { Content = "Cancelled\n", ContentType = "application/json", StatusCode = 200 };
            }
            logger.LogInformation("Returning Hello World\n");
            return new ContentResult() { Content = "Hello World\n", ContentType = "application/json", StatusCode = 200 };
        }

    }
}