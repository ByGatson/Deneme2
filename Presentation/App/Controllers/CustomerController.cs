using Application.Features.Customer.Commands.Create;
using Application.Features.Customer.Request.GetAll;
using Application.Features.Customer.Request.GetAllById;
using Application.Result;
using Domain.Entities;
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
        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllCustomerRequest());
            return Ok(Result<List<Customer>>.Success(response));
        }
        [HttpGet, Route("getbyid/id")]
        public async Task<IActionResult> GetAllById(string id)
        {
            var response = await _mediatR.Send(new GetAllByIdCustomerRequest(id));
            return Ok(Result<List<Customer>>.Success(response));
        }
    }
}
