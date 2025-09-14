using Application.Interfaces.Redis;
using MediatR;

namespace Application.Features
{
    public class TestCommandHandler : IRequestHandler<TestCommand, bool>
    {
        private readonly ICacheService _redis;

        public TestCommandHandler(ICacheService redis)
        {
            _redis = redis;
        }

        public async Task<bool> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            await _redis.SetAsync("testKey", "deneme");
            Console.WriteLine(await _redis.GetAsync("testKey"));
            return true;
        }
    }
}
