using Application.Features.Basket.Commands.AddToBasket;
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
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public BasketController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost, Route("add-product-basket")]
        public async Task<IActionResult> AddProductToBasket([FromBody] AddToBasketCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(Result<List<Product>>.Success(response));
        }
    }
}
