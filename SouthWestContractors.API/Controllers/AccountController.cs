using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SouthWestContractors.Application.Contracts.Identity;
using SouthWestContractors.Application.Models.Authentication;
using System.Threading.Tasks;

namespace SouthWestContractors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(IAuthenticationService authenticationService, IHttpContextAccessor httpContextAccessor)
        {
            _authenticationService = authenticationService;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync([FromBody] RegistrationRequest request)
        {
            var response = await _authenticationService.RegisterAsync(request);
            return Ok(response);
        }
    }
}
