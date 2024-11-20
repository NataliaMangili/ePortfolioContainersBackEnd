using ePortfolio.Application.Projects.Commands.Create;
using System.ComponentModel.DataAnnotations;

namespace ePortfolio.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IMediator mediator, ILogger<ProjectsController> logger) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<ProjectsController> _logger = logger;

    [HttpPost("CreateProject")]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDTO request)
    {
        // O middleware trata as exceções
        var command = new CreateProjectCommand(request);
        var result = await _mediator.Send(command);

        if (result)
        {
            return Ok(new { success = true, message = "Project created successfully." });
        }

        return BadRequest(new { success = false, message = "Failed to create the project." });
    }
}