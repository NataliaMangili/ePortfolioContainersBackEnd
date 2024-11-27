using ePortfolio.Application.Projects.Commands.Create;
using ePortfolio.Domain.Models;
using ePortfolio.Domain.Ports;
using ePortfolio.Infrastructure;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ePortfolio.Application.Contacts.Commands.Create;

public class CreateContactHandler : IRequestHandler<CreateContactCommand, bool>
{
    private readonly ILogger<CreateContactCommand> _logger;
    private readonly IWriteRepository<Contact, Guid, EportfolioContext> _writeRepository;

    public CreateContactHandler(ILogger<CreateContactCommand> logger, IWriteRepository<Contact, Guid, EportfolioContext> writeRepository)
    {
        _logger = logger;
        _writeRepository = writeRepository;
    }

    public async Task<bool> Handle(CreateContactCommand command, CancellationToken cancellationToken)
    {
        try
        {
            List<Contact> contactsToInsert = command.dto.contacts
                .Select(contact =>
                new Contact(
                    contact.Link,
                    contact.Econtact,
                    command.dto.userInclusionId,
                    contact.Description
                )
            ).ToList();

           await _writeRepository.AddRangeAsync(contactsToInsert);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while attempting to process the CreateContact command.");
            throw new Exception("Unexpected error occurred while attempting to save the project.");
        }
    }
}