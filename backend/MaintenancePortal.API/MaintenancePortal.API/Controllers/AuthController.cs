using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MaintenancePortal.API.Data;
using MaintenancePortal.API.Dtos;
using MaintenancePortal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MaintenancePortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            if (await UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                Role = userForRegisterDto.Role,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _context.Users.AddAsync(userToCreate);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == userForLoginDto.Username);

            if (user == null)
                return Unauthorized("Invalid username");

            if (!VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized("Invalid password");

            // Create a DTO to send back to the client
            var userToReturn = new UserDtos
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Token = "this is a fake token" // We will create a real token later
            };

            return Ok(userToReturn);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
            return false;
        }
    }
}


