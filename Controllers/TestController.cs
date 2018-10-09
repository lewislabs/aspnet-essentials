using Microsoft.AspNetCore.Mvc;

namespace aspnet_essentials
{
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return new ContentResult() { Content = "Hello World\n", ContentType = "application/json", StatusCode = 200 };
        }

    }
}