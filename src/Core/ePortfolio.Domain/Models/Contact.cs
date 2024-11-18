using ePortfolio.Domain.Enums;

namespace ePortfolio.Domain.Models;

public class Contact : Entity<Guid>
{
    private Contact() { }
    public string Link { get; private set; }
    public EContact Econtact { get; private set; }
    public string Description { get; private set; }
    public Guid UserId { get; set; }

    public Contact(string link, EContact _Econtact, Guid userInclusion,string description)
        : base(Guid.NewGuid(), userInclusion)
    {
        Link = link;
        Econtact = _Econtact;
        Description = description;
    }

    public void UpdateContact(string link, EContact eContact, string description)
    {
        SetLink(link);
        SetContactType(eContact);
        SetDescription(description);
    }

    public void SetLink(string link)
    {
        if (string.IsNullOrWhiteSpace(link))
            throw new ArgumentException("Link cannot be empty.");

        if (link.Length > 200)
            throw new ArgumentException("Link cannot exceed 200 characters.");

        if (!Uri.TryCreate(link, UriKind.Absolute, out _))
            throw new ArgumentException("Link is not a valid URL.");

        Link = link;
    }

    public void SetContactType(EContact eContact)
    {
        if (!Enum.IsDefined(typeof(EContact), eContact))
            throw new ArgumentException("Invalid contact type.");

        Econtact = eContact;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.");

        if (description.Length > 500)
            throw new ArgumentException("Description cannot exceed 500 characters.");

        Description = description;
    }
}


