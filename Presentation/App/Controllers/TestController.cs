using Application.Features;
using Application.Interfaces.JwtToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly ITokenService _tokenService;

        public TestController(IMediator mediatR, ITokenService tokenService)
        {
            _mediatR = mediatR;
            _tokenService = tokenService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Testing([FromBody] TestCommand request)
        {
            var response = await _mediatR.Send(request);
            var token = _tokenService.CreateAccessToken();
            return Ok("test is okey ->");
        }
        [HttpPost]
        public IActionResult TokenTest()
        {
            var token = _tokenService.CreateAccessToken();
            return Ok(token);
        }

    }
}
