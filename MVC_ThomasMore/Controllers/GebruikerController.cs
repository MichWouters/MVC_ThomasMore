using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using MVC_ThomasMore.Data.Entities;
using MVC_ThomasMore.DTO.Gebruiker;
using MVC_ThomasMore.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MVC_ThomasMore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GebruikerController: ControllerBase
    {
        private UserManager<CustomUser> _userManager;
        private SignInManager<CustomUser> _signInManager;

        public GebruikerController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager; 
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login (LoginDto dto)
        {
            // Defensive coding
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomUser? user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null && !user.EmailConfirmed)
            {
                ModelState.AddModelError("message", "Email adres is nog niet bevestigd!");
                return BadRequest(ModelState);
            }

            if (await _userManager.CheckPasswordAsync(user, dto.Password) == false)
            {
                ModelState.AddModelError("message", "Verkeerde logincombinatie");
                return BadRequest(ModelState);
            }

            // Actual login method
            var result = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false,false);

            // Als succesvol -> Print Jwt ticket
            if (result.Succeeded)
            {
                // Add claims like username, email etc. Who do I claim to be?
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                // Add roles like admin, super admin. What authority do I have?
                //IList<string> userRoles = await _userManager.GetRolesAsync(user);

                IList<string> userRoles = new List<string>
                {
                    "user", "admin"
                };

                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var token = Token.GetToken(claims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            else
            {
                ModelState.AddModelError("message", "Ongeldige login");
                return Unauthorized(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistratieDTO dto)
        {
            // Defensive coding
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomUser? gebruiker = await _userManager.FindByEmailAsync(dto.Email);
            if (gebruiker != null)
            {
                ModelState.AddModelError("message", "Deze email bestaat al in de database"); // Do NOT do this cool thing -> Waardevolle info voor hackers\
                return BadRequest(ModelState);
            }

            CustomUser newUser = new CustomUser
            {
                UserName = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Naam = dto.Name,
                Adres = dto.Adress,
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                TwoFactorEnabled = false,
                PasswordHash = "123",
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, dto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("message", error.Description);
                }

                return BadRequest(ModelState);
            }
        }
    }
}
