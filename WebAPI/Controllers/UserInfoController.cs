using Microsoft.AspNetCore.Mvc;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserInfoController : BaseController<UserInfo>
{
    public UserInfoController(IRepository<UserInfo> repositoryConnection) : base(repositoryConnection)
    {
    }
}