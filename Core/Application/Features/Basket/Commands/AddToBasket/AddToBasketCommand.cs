using MediatR;

namespace Application.Features.Basket.Commands.AddToBasket
{
    public sealed record AddToBasketCommand(string productId) : IRequest<List<Domain.Entities.Product>>
    {

    }
}
