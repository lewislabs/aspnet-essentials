using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_essentials
{
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet("test")]
        public IActionResult Test([FromServices] IHttpContextAccessor httpContextAccessor)
        {
            var headers = httpContextAccessor.HttpContext.Request.Headers;
            var testHeader = headers.ContainsKey("test") ? headers["test"].ToArray()[0] : "NA";
            return new ContentResult() { Content = $"Hello World\ntest={testHeader}\n", ContentType = "application/json", StatusCode = 200 };
        }

    }
}