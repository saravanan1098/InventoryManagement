using InventoryManagement.Dto;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;


namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration config;
        private InventoryDbContext db;
        public LoginController(IConfiguration _config, InventoryDbContext _db)
        {
            config = _config;
            db = _db;
        }
        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] User request)
        {

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(request.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            request.Password = savedPasswordHash;
            db.Users.Add(request);
            db.SaveChanges();
            return Ok(request);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Responsemodel>> Login([FromBody] UserDto userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                Responsemodel responsemodel = new Responsemodel();
                responsemodel.Username = user.Username;
                responsemodel.Role = user.Role;
                responsemodel.Email = user.Email;
                responsemodel.Token = token;
                return responsemodel;
            }
            return NotFound("User not found");
        }

        private string Generate(User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new[]

            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserDto userLogin)
        {
            /* Fetch the stored value */
            string savedPasswordHash = db.Users.FirstOrDefault(u => u.Email == userLogin.Email).Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(userLogin.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    //throw new UnauthorizedAccessException();
                    return null;
                }

            }

            var currentUser = db.Users.FirstOrDefault(o => o.Email.ToLower() ==
                userLogin.Email.ToLower());
            return currentUser;

        }

    }
}
