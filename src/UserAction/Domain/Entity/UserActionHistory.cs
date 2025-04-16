using UserAction.Domain.Common;

namespace UserAction.Domain.Entity
{
    public class UserActionHistory : BaseEntity
    {

        #region props
        public Guid UserId { get; private set; }
        public Guid CatalogId { get; private set; }
        public string? CategoryName { get; private set; }
        public ActionType ActionType { get; private set; }
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
}
