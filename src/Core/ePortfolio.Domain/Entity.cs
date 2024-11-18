
namespace ePortfolio.Domain;

public abstract class Entity<TId> : IEntity<TId>
{
    public TId Id { get; protected set; }
    public Guid UserInclusion { get; set; }
    public DateTime Inclusion { get; }

    protected Entity()
    {
    }

    protected Entity(TId id, Guid userInclusion) : this()
    {
        Id = id;
        UserInclusion = userInclusion;
        Inclusion = DateTime.UtcNow;
    }

    public bool IsTransient()
    {
        return Id.Equals(default(TId));
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (Entity<TId>)obj;

        if (IsTransient() || other.IsTransient())
            return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        if (Equals(left, null))
            return Equals(right, null);

        return left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !(left == right);
    }
}
