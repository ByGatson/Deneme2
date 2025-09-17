using Application.Features.Company.Commands.Create;
using Application.Features.Company.Request.GetAll;
using Application.Features.Company.Request.GetAllById;
using Application.Result;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CompanyController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<bool>.Success(response));
        }
        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<bool>.Success(response));
        }
        [HttpDelete, Route("delete/id")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediatR.Send(new DeleteCompanyCommand(id));
            return Ok(Result<bool>.Success(response));
        }
        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllCompanyRequest());
            return Ok(Result<List<Company>>.Success(response));
        }
        [HttpGet, Route("getallbyuserid/id")]
        public async Task<IActionResult> GetAllByUserId(string id)
        {
            var response = await _mediatR.Send(new GetAllByIdRequest(id));
            return Ok(Result<List<Company>>.Success(response));
        }
    }
}
