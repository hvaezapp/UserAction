using MassTransit;
using UserAction.DbContexts.Sql.SqlServer;
using UserAction.Domain.Entity;
using UserAction.Infrastructure.Consumers.IntegrationEvents;

namespace UserAction.Infrastructure.Consumers;

public class UserActionAddedEventConsumer : IConsumer<UserActionAddedEvent>
{
    private readonly UserActionContext _dbContext;
    public UserActionAddedEventConsumer(UserActionContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task Consume(ConsumeContext<UserActionAddedEvent> context)
    {
        var newUserActionHistory = new UserActionHistory(context.Message.userId , 
                                                        context.Message.catalogId , 
                                                        context.Message.categoryName ,
                                                        context.Message.ActionType);

        await _dbContext.UserActionHistory.AddAsync(newUserActionHistory);
        await _dbContext.SaveChangesAsync();
    }
}
