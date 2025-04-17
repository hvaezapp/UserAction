using MassTransit;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Recommendation.Infrastructure.Consumers.IntegrationEvents;
using UserAction.DbContexts.Sql.SqlServer;
using UserAction.Dtos;
using UserAction.Handlers;

namespace UserAction.Infrastructure.Consumers
{
    public class UserActionHistoryEventConsumer : IConsumer<UserActionHistoryEvent>
    {
        public const byte TakeCount = 10;

        private readonly UserActionContext _dbContext;
        private readonly IRedisHandler _redisHandler;

        public UserActionHistoryEventConsumer(UserActionContext dbContext, IRedisHandler redisHandler)
        {
            _dbContext = dbContext;
            _redisHandler = redisHandler;
        }

        public async Task Consume(ConsumeContext<UserActionHistoryEvent> context)
        {
            // fetch last 10 user action detail items
            var lastUserActionHistories = (await _dbContext
                                                      .UserActionHistory
                                                      .Where(a => a.UserId == context.Message.userId)
                                                      .OrderByDescending(s => s.CreatedOn)
                                                      .Take(TakeCount)
                                                      .ToListAsync()).Select(a => new GetUserActionHistoryDto
                                                      {
                                                          CatalogSlug = a.CatalogSlug,
                                                          CategoryName = a.CategoryName,
                                                          ActionType = a.ActionType,
                                                      });

            // write to redis
            await _redisHandler.UpdateUserActionHistory(context.Message.userId.ToString(), lastUserActionHistories);

        }


    }
}
