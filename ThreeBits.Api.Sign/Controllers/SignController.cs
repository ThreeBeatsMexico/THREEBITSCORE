using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreeBits.Business.Filters;
using ThreeBits.Interfaces.School;
using ThreeBits.Interfaces.Security.Security;
using ThreeBits.Interfaces.Sign;

namespace ThreeBits.Api.Sign.Controllers
{
    [EnableCors("ThreeBitsPolicy")]
    [ApiController]
    [xAppIdHeader(true)]
    [Route("api/v1/Sign")]
    public class SignController : _BaseController
    {
        private readonly ILogger<SchoolController> _logger;

        private readonly ISignServiceBR _service;

        private readonly ISecurityServiceBR _securityServiceBR;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SignController(ILogger<SchoolController> logger, ISignServiceBR service, IHttpContextAccessor httpContextAccessor, ISecurityServiceBR securityServiceBR)
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _securityServiceBR = securityServiceBR;
        }








    }
}
