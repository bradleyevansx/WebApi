using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IRepository<UserInfo> _userInfoRepository;

    public AuthController(IRepository<UserInfo> userInfoRepository, ITokenRepository tokenRepository)
    {
        _userInfoRepository = userInfoRepository;
        _tokenRepository = tokenRepository;
    }

    

    [HttpPost("register")]
    public IActionResult Register(UserInfo request)
    {

        _userInfoRepository.Add(new UserInfo
        {
            id = Guid.NewGuid().ToString(),
            Username = request.Username,
            Password = request.Password
        });

        return Ok();
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserInfo request)
    {
        var check = await _userInfoRepository.CheckUserCreds(request);

        var token = _tokenRepository.CreateToken(check);

        return Ok(token);
    }

}