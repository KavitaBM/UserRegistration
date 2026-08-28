using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly AppUserContext _context;

        public UserInfoController(AppUserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(UserInfo user)
        {
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(UserInfo user)
        {
            var existingUser = _context.Users.Find(user.userId);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.firstName = user.firstName;
            existingUser.lastName = user.lastName;
            existingUser.email = user.email;
            existingUser.phone = user.phone;
            existingUser.address = user.address;
            _context.SaveChanges();
            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok("User Deleted Successfully");
        }
    }
}
