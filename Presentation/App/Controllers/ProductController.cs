using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Delete;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Request.GetAll;
using Application.Features.Product.Request.GetAllById;
using Application.Result;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public ProductController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<bool>.Success(response));
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<bool>.Success(response));
        }

        [HttpDelete, Route("delete/id")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediatR.Send(new DeleteProductCommand(id));
            return Ok(Result<bool>.Success(response));
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllProductRequest());
            return Ok(Result<List<Product>>.Success(response));
        }

        [HttpGet, Route("getbyid/id")]
        public async Task<IActionResult> GetAllById(string id)
        {
            var response = await _mediatR.Send(new GetAllByIdProductRequest(id));
            return Ok(Result<List<Product>>.Success(response));
        }

    }
}
