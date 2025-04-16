using UserAction.Domain.Common;

namespace UserAction.Domain.Entity;

public class UserActionHistory : BaseEntity
{

    #region props
    public Guid UserId { get; private set; }
    public string? CatalogSlug { get; private set; }
    public string? CategoryName { get; private set; }
    public ActionType ActionType { get; private set; }
    #endregion


    #region ctors
    public UserActionHistory(Guid userId, string? catalogSlug, string? categoryName, ActionType actionType)
    {
        UserId = userId;
        CatalogSlug = catalogSlug;
        CategoryName = categoryName;
        ActionType = actionType;
    }
    #endregion

}

#region enums
public enum ActionType
{
    Like,
    View,
    Bookmark,
    Comment
}
#endregion
