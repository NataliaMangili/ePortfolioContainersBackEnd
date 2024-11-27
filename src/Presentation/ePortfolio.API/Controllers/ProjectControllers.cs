using ePortfolio.Application.Projects.Commands.Create;
using Microsoft.AspNetCore.Authorization;

namespace ePortfolio.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProjectController(IMediator mediator, ILogger<ProjectController> logger) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<ProjectController> _logger = logger;

    [HttpPost("CreateProject")]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDTO request)
    {
        // O middleware trata as exceções
        var command = new CreateProjectCommand(request);
        var result = await _mediator.Send(command);

        if (result) return Ok(new { success = true, message = "Project created successfully." });

        return BadRequest(new { success = false, message = "Failed to create the project." });
    }
}