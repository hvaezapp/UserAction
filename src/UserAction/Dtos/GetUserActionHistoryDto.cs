using UserAction.Domain.Entity;

namespace UserAction.Dtos;

public class GetUserActionHistoryDto
{
    public string? CatalogSlug { get;  set; }
    public string? CategoryName { get;  set; }
    public ActionType ActionType { get;  set; }
}
