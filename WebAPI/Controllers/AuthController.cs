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
    private readonly IConfiguration _configuration;
    private readonly IRepository<UserInfo> _userInfoRepository;

    public AuthController(IConfiguration configuration, IRepository<UserInfo> userInfoRepository)
    {
        _configuration = configuration;
        _userInfoRepository = userInfoRepository;
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
    public async Task<ActionResult<string>> Login(NewUser request)
    {
        var check = await _userInfoRepository.CheckUserCreds(request);

        var token = CreateToken(check);

        return Ok(token);

    }

    private string CreateToken(UserInfo user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.UserData, user.id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}