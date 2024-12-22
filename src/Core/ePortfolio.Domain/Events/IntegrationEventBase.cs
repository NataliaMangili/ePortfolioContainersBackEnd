namespace ePortfolio.Domain.Events;

public abstract class IntegrationEventBase
{
    public Guid Id { get; private set; }
    public DateTime CreationDate { get; private set; }

    protected IntegrationEventBase()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }
}