using Microsoft.AspNetCore.Mvc;
using users_crud.Model;

namespace users_crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> Users()
        {
            return new List<User> {
                new User{ Name = "Daisy", Id = 1, DateBirth = new DateTime(1988, 08, 08) }
            };
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users());
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            var users = Users();
            users.Add(user);
            return Ok(users);
        }
    }
}