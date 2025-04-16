using UserAction.Domain.Entity;

namespace UserAction.Infrastructure.Consumers.IntegrationEvents;

public record UserActionAddedEvent(Guid userId, string catalogSlug, string? categoryName, ActionType ActionType);

