using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Milmom_Service.InterfaceService;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.Dtos;

namespace MilmomStore.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AccountApplication> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AccountApplication> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AccountApplication> userManager, ITokenService tokenService, 
            SignInManager<AccountApplication> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToList(),

                    Token = _tokenService.createToken(user)
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var accountApp = new AccountApplication
                {
                    UserName = registerDto.Username,
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    Address = registerDto.Address,
                    Phone = registerDto.Phone,
                    Image = registerDto.Image
                };

                

                var createdUser = await _userManager.CreateAsync(accountApp, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(accountApp, "CUSTOMER");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = accountApp.UserName,
                                Email = accountApp.Email,
                                Name = accountApp.Name,
                                Address = accountApp.Address,
                                Phone = accountApp.Phone,
                                Image = accountApp.Image,
                                Token = _tokenService.createToken(accountApp)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("create account")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto createAccountDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (string.IsNullOrEmpty(createAccountDto.Role))
                    return BadRequest("Role is required.");

                var accountApp = new AccountApplication
                {
                    UserName = createAccountDto.Username,
                    Name = createAccountDto.Name,
                    Email = createAccountDto.Email,
                    Address = createAccountDto.Address,
                    Phone = createAccountDto.Phone,
                    Image = createAccountDto.Image
                };



                var createdUser = await _userManager.CreateAsync(accountApp, createAccountDto.Password);

                

                if (createdUser.Succeeded)
                {
                    var role = createAccountDto.Role.ToUpper();
                    var roleExists = await _roleManager.RoleExistsAsync(role);
                    if (roleExists)
                    {
                        if (createAccountDto.Role.ToUpper() == "ADMIN")
                        {
                            return BadRequest("Cannot create account with role 'Admin'.");
                        }
                        var roleResult = await _userManager.AddToRoleAsync(accountApp, createAccountDto.Role);


                        if (roleResult.Succeeded)
                        {
                            var userRoles = await _userManager.GetRolesAsync(accountApp);
                            return Ok(
                                new NewUserDto
                                {
                                    UserName = accountApp.UserName,
                                    Email = accountApp.Email,
                                    Name = accountApp.Name,
                                    Address = accountApp.Address,
                                    Phone = accountApp.Phone,
                                    Image = accountApp.Image,
                                    Roles = userRoles.ToList(),
                                    Token = _tokenService.createToken(accountApp)
                                }
                            );
                        }
                        else
                        {
                            return StatusCode(500, roleResult.Errors);
                        }
                    }
                    else
                    {
                        return BadRequest($"Role '{createAccountDto.Role}' does not exist.");
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
