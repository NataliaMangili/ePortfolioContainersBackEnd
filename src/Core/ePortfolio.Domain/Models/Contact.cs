using System.ComponentModel.DataAnnotations.Schema;
using ePortfolio.Domain.Enums;
using ePortfolio.Domain.ValueObjects;

namespace ePortfolio.Domain.Models;

public class Contact : Entity<Guid>
{
    public string Link { get; private set; }
    public EContact Econtact { get; private set; }
    public string Description { get; private set; }
    
    public Guid UserId { get; set; }

    private Contact()
    {
    }

    public Contact(Guid id, string link, EContact _Econtact, Guid userInclusion,string description)
        : base(id, userInclusion)
    {
        Link = link;
        Econtact = _Econtact;
        Description = description;
    }
}
