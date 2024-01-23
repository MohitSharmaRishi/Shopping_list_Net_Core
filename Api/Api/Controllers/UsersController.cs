using Api.Database;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDBContext db;
        private readonly IConfiguration _configuration;
        public UsersController(MyDBContext _db,IConfiguration configuration)
        {
            db = _db;
            _configuration = configuration;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return Ok(db.Users.ToList());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            return Ok(db.Users.Find(id));
        }

        
        [HttpPost]
        public IActionResult Save([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (user.UID == 0)
            {
                //if (string.IsNullOrEmpty(user.GUID)) { user.GUID = Guid.NewGuid().ToString(); }
                db.Users.Add(user);
                db.SaveChanges();
                return Ok(user);
            }

            else
            {
                User ExistingUser = db.Users.Find(user.UID);
                ExistingUser.Email = user.Email;
                ExistingUser.UserName = user.Email;
                ExistingUser.Mobile = user.Email;
                //ExistingUser.Address = user.Address;
                //ExistingUser.Status = user.Status;
                //ExistingUser.IsVerified = user.IsVerified;

                db.SaveChanges();
                return Ok(ExistingUser);
            }

        }

        
        [HttpPost("Login")]
        public string Login([FromBody] creds creds)
        {
            string Email=creds.Email, PWD=creds.PWD;
            var user = db.Users.SingleOrDefault(x=>x.Email==Email && x.PWD==PWD    );
            if (user == null) return null;
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("UID", user.UID.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
