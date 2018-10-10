using System;
using System.Collections.Generic;
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

        [HttpGet("no-sync")]
        public async Task<IActionResult> NoSync()
        {
            var list = new List<bool>();
            var tasks = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                tasks.Add(CreateTask(list));
            }
            await Task.WhenAll(tasks);
            return new ContentResult() { Content = "TEST" };
        }

        private async Task CreateTask(List<bool> list)
        {
            await Task.Delay(100);
            list.Add(true);
        }

    }
}