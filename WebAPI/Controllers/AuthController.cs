using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;

namespace WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController, AllowAnonymous]
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

    [HttpGet("refresh")]
    public async Task<IActionResult> Login([FromQuery] string refreshTokenId)
    {
        var response = await _tokenRepository.CreateAuthenticationResponseAsync(refreshTokenId);

        return Ok(response);
    } 
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserInfo request)
    {
        var check = await _userInfoRepository.CheckUserCreds(request);

        var response = await _tokenRepository.CreateAuthenticationResponseAsync(check);

        return Ok(response);
    }
    

}