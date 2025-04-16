using UserAction.Domain.Entity;

namespace UserAction.Infrastructure.Consumers.IntegrationEvents;

public record UserActionAddedEvent(Guid userId, Guid catalogId, string? categoryName, ActionType ActionType);

