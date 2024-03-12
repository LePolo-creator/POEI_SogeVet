using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SogeVet.Server.Data;
using SogeVet.Server.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookAPI.Controllers
{
    [Route("api")]
    [ApiController]


    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly StoreContext _context;
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }



        public AuthenticationController(IConfiguration configuration,StoreContext context)
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            _context = context;
        }

        [HttpPost("login")]
        public ActionResult Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
            
            // Step 1: validate the username/password
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName,
                authenticationRequestBody.Password);
            
            if (user == null)
            {
                return Unauthorized();
            }

            // Step 2: create a token
            var securityKey = new SymmetricSecurityKey(
                Convert.FromBase64String(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("firstname", user.FirstName));
            claimsForToken.Add(new Claim("lastname", user.LastName));
            claimsForToken.Add(new Claim("role", "admin"));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            return Ok(new { token = tokenToReturn });
        }

        private User ValidateUserCredentials(string? mail, string? password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            // La vérification devrait se faire à partie des données de la BD
            // ceci est une version simplifiée :
            if (user != null && (user.Password == password))
            {
               return user;
            }
            else
            {
                return null;
            }


        }


    }
}