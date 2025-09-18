using Application.Interfaces.Redis;
using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Basket.Commands.AddToBasket
{
    public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommand, List<Domain.Entities.Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public AddToBasketCommandHandler(IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public async Task<List<Domain.Entities.Product>> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.productId);
            var currentBasketId = await _cacheService.GetAsync("basketId");
            var userId = await _cacheService.GetAsync("userId");

            if (currentBasketId is null)
            {
                var companyId = await _cacheService.GetAsync("companyId");
                var basket = new Domain.Entities.Basket() { CompanyId = companyId, UserId = userId };
                await _unitOfWork.BasketRepository.AddAsync(basket);
                await _cacheService.SetAsync("basketId", basket.Id);
                currentBasketId = basket.Id;
            }

            var response = await _unitOfWork.BasketRepository.AddProductToBasket(currentBasketId, product);

            return response;
        }
    }
}
