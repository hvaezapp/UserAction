using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using UserAction.Dtos;

namespace UserAction.Handlers
{
    public class RedisHandler : IRedisHandler
    {
        private readonly IDistributedCache _redisCache;

        public RedisHandler(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task UpdateUserActionHistory(string userId, IEnumerable<GetUserActionHistoryDto> userActionHistories)
        {
            await _redisCache.SetStringAsync(userId, JsonConvert.SerializeObject(userActionHistories));
        }

    }

}
