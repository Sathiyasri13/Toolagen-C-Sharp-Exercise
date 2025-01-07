using Microsoft.AspNetCore.Mvc;
using productslist.Models;
using System.Collections.Generic;

namespace productslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Static list of users
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "sathiya", Email = "sathiya@gmail.com" },
            new User { Id = 2, Name = "sri", Email = "sri@gmail.com" }
        };

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("Invalid user data.");

                // Auto-generate a unique ID for the new user
                user.Id = _users.Count > 0 ? _users[^1].Id + 1 : 1;

                _users.Add(user);
                return CreatedAtAction(nameof(GetAllUsers), user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                var user = _users.Find(u => u.Id == id);
                if (user == null)
                    return NotFound($"User with ID {id} not found.");

                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;

                return Ok($"User with ID {id} updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
