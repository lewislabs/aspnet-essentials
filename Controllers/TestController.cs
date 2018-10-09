using Microsoft.AspNetCore.Mvc;

namespace aspnet_essentials
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {
            return new ContentResult() { Content = "Hello World\n", ContentType = "application/json", StatusCode = 200 };
        }

    }
}