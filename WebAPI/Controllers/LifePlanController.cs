using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.Domain.Interfaces;
using WebAPI.Repository;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LifePlanController : BaseController<LifePlan>
{
    private readonly IRepository<LifePlan> _repositoryConnection;

    public LifePlanController(IRepository<LifePlan> repositoryConnection) : base(repositoryConnection)
    {
        _repositoryConnection = repositoryConnection;
    }

    [HttpGet("self")]
    public async Task<IActionResult> GetByUserIdAsync()
    {
        var userId = HttpContext.User.Identity!.Name;
        var results = await _repositoryConnection.Query()
            .Where(x => x.userId == userId).ToListAsync();

        if (results.Count is 0) return NoContent();
        return Ok(results);
    }
}