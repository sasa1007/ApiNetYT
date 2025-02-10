using Api.Dtos.Account;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };
            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "USER");
                if (roleResult.Succeeded)
                {
                    return Ok(new NewUserDto
                    {
                        Username = appUser.UserName,
                        Email = appUser.Email,
                        Token = _tokenService.CreateToken(appUser),
                    });
                }
                else
                {
                    return BadRequest(roleResult.Errors);
                }
            }
            else
            {
                return BadRequest(createdUser.Errors);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}