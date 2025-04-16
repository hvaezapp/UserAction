using UserAction.Domain.Entity;

namespace Catalog.Infrastructure.IntegrationEvents;

public record UserActionAddedEvent(Guid userId, string? catalogSlug, string? categoryName, ActionType ActionType);

