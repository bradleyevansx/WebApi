using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController, AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IUserInfoRepository _userInfoRepository;

    public AuthController(IUserInfoRepository userInfoRepository, ITokenRepository tokenRepository)
    {
        _userInfoRepository = userInfoRepository;
        _tokenRepository = tokenRepository;
    }

    

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync(UserInfo request)
    {
        var newUser = _userInfoRepository.CreateAsync(request);

        var response = await _tokenRepository.CreateAuthenticationResponseAsync(newUser.Result.Resource);

        return Ok(response);
    }

    [HttpGet("refresh")]
    public async Task<IActionResult> LoginAsync([FromQuery] string refreshTokenId)
    {
        var response = await _tokenRepository.CreateAuthenticationResponseAsync(refreshTokenId);

        return Ok(response);
    } 
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] string[] usernamePassword)
    {
        var check = await _userInfoRepository.GetByCredentialsAsync(usernamePassword[0], usernamePassword[1]);

        var response = await _tokenRepository.CreateAuthenticationResponseAsync(check);

        return Ok(response);
    }
    

}