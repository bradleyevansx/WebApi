using Microsoft.AspNetCore.Mvc;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PracticeSessionController : BaseController<PracticeSession>
{
    public PracticeSessionController(IRepository<PracticeSession> repositoryConnection) : base(repositoryConnection)
    {
    }
}