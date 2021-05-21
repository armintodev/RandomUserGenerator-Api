using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserGenerator.Api.Data.Repositories;
using UserGenerator.Api.DTOs;

namespace UserGenerator.Api.Endpoints.AccountEndpoints
{
    public class Login : BaseAsyncEndpoint.WithRequest<LoginCommand>.WithoutResponse
    {
        private readonly SignInManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        public Login(SignInManager<IdentityUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpPost("account/login")]
        public override async Task<ActionResult> HandleAsync(LoginCommand request, CancellationToken cancellationToken = new CancellationToken())
        {
            if (request is not null)
            {
                var user = await _userRepository.GetIdentityUser(request);
                await _userManager.SignInAsync(user, new AuthenticationProperties { IsPersistent = false });
                return Ok(user);
            }

            return BadRequest("request is null");
        }
    }
}
