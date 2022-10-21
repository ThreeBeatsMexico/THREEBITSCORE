using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Security;

namespace Threebits.WebApiSecurity.Controllers
{
        [EnableCors("IesCorsPolicy")]
        [ApiController]
        [Route("api/Formularios")]
        public class LoginController : Controller
        {
            private readonly ILogger<LoginController> _logger;
            private readonly ISecurityService _service;

            public LoginController(ILogger<LoginController> logger, ISecurityService service)
            {
                _logger = logger;
                _service = service;
            }

            /// <summary>
            /// Obtener Estatus Formulario.
            /// </summary>
            [HttpPost]
            [AllowAnonymous]
            [Route("Login")]
            public ActionResult Login([FromBody] Credential input)
            {



                return Ok(_service.Authenticate(input));
            }








        }
    }
