using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cyberservice_management.Helpers;
using Cyberservice_management.Model;
using Cyberservice_management.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cyberservice_management.Controllers
{   
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signManager;

        private readonly AppSettings _appSettings;

        //private IEmailSender _emailsender;



        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IOptions<AppSettings> appSettings
            //IEmailSender emailsender

        )
        {
            _userManager = userManager;
            _signManager = signInManager;
            _appSettings = appSettings.Value;
          // _emailsender = emailsender;

        }


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel formdata)
        {
            // Will hold all the errors related to registration
            List<string> errorList = new List<string>();

            var user = new IdentityUser
            {
                Email = formdata.Email,
                UserName = formdata.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, formdata.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

               return Ok(new { username = user.UserName, email = user.Email, status = 1, message = "Registration Successful" });

            }
             else
             { 
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    errorList.Add(error.Description);
                }
             }

            return BadRequest(new JsonResult(errorList));

        }

        // Login Method
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel formdata)
        {
            // Get the User from Database
            var user = await _userManager.FindByNameAsync(formdata.Username);

            //get user Role
            var roles = await _userManager.GetRolesAsync(user);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));

            double tokenExpiryTime = Convert.ToDouble(_appSettings.ExpireTime);

            if (user != null && await _userManager.CheckPasswordAsync(user, formdata.Password))
            {

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, formdata.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                        new Claim("LoggedOn", DateTime.Now.ToString()),

                     }),

                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _appSettings.Site,
                    Audience = _appSettings.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                };

                // Generate Token

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), expiration = token.ValidTo, username = user.UserName, userRole = roles.FirstOrDefault() });

            }

            // return error
            ModelState.AddModelError("", "Username/Password was not Found");
            return Unauthorized(new { LoginError = "Please Check the Login Credentials - Invalid Username/Password was entered" });

        }

       // [HttpGet("[action]")]
        //[AllowAnonymous]
       // public async Task<IActionResult> ConfirmEmail(string userId, string code)
       // {
            //if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
           // {
             //   ModelState.AddModelError("", "User Id and Code are required");
               // return BadRequest(ModelState);

           // }

          //  var user = await _userManager.FindByIdAsync(userId);

           // if (user == null)
           // {
               //return new JsonResult("ERROR");
           // }

           // if (user.EmailConfirmed)
            //{
              //  return Redirect("/login");
          //  }

           // var result = await _userManager.ConfirmEmailAsync(user, code);

          //  if (result.Succeeded)
          //  {

               // return RedirectToAction("EmailConfirmed", "Notifications", new { userId, code });

           // }
           // else
           // {
              //  List<string> errors = new List<string>();
              //  foreach (var error in result.Errors)
            //{
              // /     errors.Add(error.ToString());
              //  }
              //  return new JsonResult(errors);
           // }


        //}
    }
}