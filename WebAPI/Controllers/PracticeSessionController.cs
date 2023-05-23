using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PracticeSessionController : BaseController<PracticeSession>
{
    private readonly IRepository<PracticeSession> _repositoryConnection;

    public PracticeSessionController(IRepository<PracticeSession> repositoryConnection) : base(repositoryConnection)
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