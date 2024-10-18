using ePortfolio.Domain.Enums;
using ePortfolio.Domain.ValueObjects;

namespace ePortfolio.Domain.Models;

public class Contact : Entity<Guid>
{
    public string Link { get; private set; }
    public EContact Econtact { get; private set; }

    public Contact(Guid id, string link, EContact _Econtact, Guid userInclusion)
        : base(id, userInclusion)
    {
        Link = link;
        Econtact = _Econtact;
    }
}
