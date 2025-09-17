using Application.Features.User.Create;
using Application.Features.User.Login;
using Application.Features.User.Logout;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public UserController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginAppUserRequest request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpPost, Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateAppUserCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpGet, Route("logout")]
        public async Task<IActionResult> Logout()
        {
            var response = await _mediatR.Send(new LogoutAppUserRequest());
            return Ok(response);
        }
    }
}
