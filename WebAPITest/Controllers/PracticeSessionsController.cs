using Microsoft.AspNetCore.Mvc;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PracticeSessionsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PracticeSessionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    
    /*[HttpGet(nameof(GetAllByUserId))]
    public async Task<IActionResult> GetAllByUserId([FromQuery] string userId) =>
        Ok(await _unitOfWork.PracticeSessions.GetAllPracticeSessionsByUserId(userId));*/

    [HttpPost(nameof(CreatePracticeSession))]
    public IActionResult CreatePracticeSession(PracticeSession newSession)
    {
        var result = _unitOfWork.PracticeSessions.Add(newSession);
        if (result is not null) return Ok("PracticeSession Created");
        else return BadRequest("Error in Creating the PracticeSession");
    }
}