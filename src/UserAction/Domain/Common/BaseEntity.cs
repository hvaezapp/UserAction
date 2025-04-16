namespace UserAction.Domain.Common;

public class BaseDomainEntity<T>
{
    public T Id { get; protected set; }
    public DateTime CreatedOn { get; private set; }

    protected BaseDomainEntity()
    {
        CreatedOn = DateTime.Now;
    }
}

public abstract class BaseEntity : BaseDomainEntity<Guid>
{

}
