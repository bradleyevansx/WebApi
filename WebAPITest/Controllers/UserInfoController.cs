using Microsoft.AspNetCore.Mvc;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserInfoController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UserInfoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpPost(nameof(CreateUser))]
    public IActionResult CreateUser(UserInfo user)
    {
        var result = _unitOfWork.UserInfo.Add(user);
        if (result is not null) return Ok("User Created");
        else return BadRequest("Error in Creating the User");
    }

    [HttpDelete(nameof(DeleteUser))]
    public IActionResult DeleteUser(UserInfo user)
    {
        var result = _unitOfWork.UserInfo.Delete(user.id, user.id);
        if (result is not null) return Ok("User Deleted");
        else return BadRequest("Error in Deleting the User");
    }
}