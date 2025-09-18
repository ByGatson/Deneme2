using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Delete;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Requests.GetAll;
using Application.Result;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CategoryController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<bool>.Success(response));
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<bool>.Success(response));
        }

        [HttpDelete, Route("delete/id")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediatR.Send(new DeleteCategoryCommand(id));
            return Ok(Result<bool>.Success(response));
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllCategoriesRequest());
            return Ok(Result<List<Category>>.Success(response));
        }
    }
}
