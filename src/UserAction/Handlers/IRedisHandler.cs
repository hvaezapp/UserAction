using UserAction.Dtos;

namespace UserAction.Handlers;

public interface IRedisHandler
{
    Task UpdateUserActionHistory(string userId, IEnumerable<GetUserActionHistoryDto> userActionHistories);
}
