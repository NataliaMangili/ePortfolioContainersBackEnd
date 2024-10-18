using System.ComponentModel.DataAnnotations.Schema;

namespace ePortfolio.Domain;

public interface IEntity<TId>
{
    TId Id { get; }
    Guid UserInclusion { get; set; }
    DateTime Inclusion { get; }
    bool IsTransient();
}