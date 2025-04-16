using Catalog.Infrastructure.IntegrationEvents;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using UserAction.DbContexts.Sql.SqlServer;
using UserAction.Domain.Entity;

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
        var userActionHistory = await _dbContext.UserActionHistory
                                                .FirstOrDefaultAsync(a => a.UserId == context.Message.userId 
                                                 && a.CatalogSlug.Equals(context.Message.catalogSlug));
        if (userActionHistory is null)
        {

            var newUserActionHistory = new UserActionHistory(context.Message.userId,
                                                            context.Message.catalogSlug,
                                                            context.Message.categoryName,
                                                            context.Message.ActionType);

            await _dbContext.UserActionHistory.AddAsync(newUserActionHistory);
            await _dbContext.SaveChangesAsync();
        }

    }
}
