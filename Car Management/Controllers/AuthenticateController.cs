using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Car_Management.Data;
using Car_Management.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Car_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        private SignInManager<ApplicationUser> _signIn;
        private ILogger<AuthenticateController> _logger;
        private IPasswordHasher<ApplicationUser> _hasher;
        private IConfiguration _config;

        public AuthenticateController(
            ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AuthenticateController> ilogger,
            UserManager<ApplicationUser> userManager,
            IPasswordHasher<ApplicationUser> hasher,
            IConfiguration config
            )
        {
            _userManager = userManager;
            _context = context;
            _signIn = signInManager;
            _logger = ilogger;
            _hasher = hasher;
            _config = config;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]LoginModel fi_RegInfo, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser() { UserName = fi_RegInfo.UserName, PasswordHash = fi_RegInfo.Password };
                var result = await _userManager.CreateAsync(user, fi_RegInfo.Password);
                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _userManager.AddClaimAsync(user, new Claim("SuperUser", "true"));
                    _logger.LogInformation(" Account Created");
                    await _signIn.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return Ok("suceessfully Registered");
                }
                else
                {
                    _logger.LogInformation($"Exception catched when logging ");
                    return BadRequest("Failed to register");
                }
            }
            return Redirect("api/Authenticate/Login");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var result = await _signIn.PasswordSignInAsync(model.UserName, model.Password, model.Rememberme, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);
                    var token = CreateToken(user);
                    return Ok(new { token });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown:{ex}");
            }
            return BadRequest("Failed to login");
        }
        [HttpPost("api/auth/Token")]
        public IActionResult CreateToken([FromBody] ApplicationUser user)
        {
            try
            {

                var Claims = new Claim[]
                {
                            new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: _config["Token:Issuer"],
                    audience: _config["Token:Audience"],
                    claims: Claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Exception occured while creating token{ex}");
            }
            return BadRequest("Failed to create Token");
        }
    }
}
