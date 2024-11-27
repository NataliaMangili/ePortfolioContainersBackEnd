using ePortfolio.Domain.Enums;
using ePortfolio.Domain.Models;

namespace ePortfolio.Application.Contacts.Commands.Create;

public record CreateContactDTO(
    Guid userInclusionId,
    IReadOnlyCollection<Contacts> contacts
);

public record Contacts(
    string Link,
    string Description,
    EContact Econtact
);
