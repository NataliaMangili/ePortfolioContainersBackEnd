namespace ePortfolio.Application.Contacts.Commands.Create;

public record CreateContactCommand(CreateContactDTO dto) : IRequest<bool>;
