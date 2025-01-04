using ePortfolio.Application.Medias.Commands.Create;
using ePortfolio.Domain.Ports.MongoDB;

namespace ePortfolio.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MediaController(IMediator mediator, ILogger<ProjectsController> logger) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<ProjectsController> _logger = logger;

    [HttpPost("SaveMediaItems")]
    public async Task<IActionResult> SaveMediaItems([FromForm] MediaItemsViewModel medias)
    {
        var command = new SaveMediaItemsCommand(medias);
        var result = await _mediator.Send(command);

        if (result) { return Ok(new { success = true, message = "Media inserted successfully." }); }

        return BadRequest(new { success = false, message = "Failed to save media items." });
    }


}