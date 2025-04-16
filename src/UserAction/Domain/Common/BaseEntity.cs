namespace UserAction.Domain.Common;

public class BaseDomainEntity<T>
{
    public T Id { get; protected set; }
    public DateTime CreatedOn { get; private set; }
}

public abstract class BaseEntity : BaseDomainEntity<Guid>
{

}
