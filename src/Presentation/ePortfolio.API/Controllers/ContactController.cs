using ePortfolio.Application.Contacts.Commands.Create;
using Microsoft.AspNetCore.Authorization;

namespace ePortfolio.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ContactController(IMediator mediator, ILogger<ContactController> logger) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<ContactController> _logger = logger;

    [HttpPost("CreateContact")]
    public async Task<IActionResult> CreateContact([FromBody] CreateContactDTO request)
    {
        CreateContactCommand command = new(request);
        bool result = await _mediator.Send(command);

        if (result) return Ok(new { success = true, message = "Contact created successfully." });

        return BadRequest(new { success = false, message = "Failed to create the Contact." });
    }
}