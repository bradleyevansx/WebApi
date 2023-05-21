using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PracticeSessionController : BaseController<PracticeSession>
{
    public PracticeSessionController(IRepository<PracticeSession> repositoryConnection) : base(repositoryConnection)
    {
    }
}