using Application.Features.Customer.Commands.Create;
using Application.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CustomerController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<bool>.Success(response));
        }
        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<bool>.Success(response));
        }
        [HttpDelete, Route("delete/id")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediatR.Send(new DeleteCustomerCommand(id));
            return Ok(Result<bool>.Success(response));
        }
    }
}
