using Microsoft.AspNetCore.Mvc;

namespace WhoAmI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhoAmI : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WhoAmI(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var language = Request.Headers["Accept-Language"].ToString().Split(',')[0];
            var software = $"{System.Runtime.InteropServices.RuntimeInformation.OSDescription} {System.Runtime.InteropServices.RuntimeInformation.OSArchitecture}";

            var response = new
            {
                ipaddress = ipAddress,
                language = language,
                software = software
            };

            return Ok(response);
        }
    }
}
