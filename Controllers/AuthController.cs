using Microsoft.AspNetCore.Mvc;

namespace SchoolDbCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // ✅ Admin credentials (for assignment/demo)
        private const string AdminEmail = "admin@school.com";
        private const string AdminPassword = "admin123";

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Email == AdminEmail && request.Password == AdminPassword)
            {
                return Ok(new { message = "Login successful" });
            }

            return Unauthorized("Invalid email or password");
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
