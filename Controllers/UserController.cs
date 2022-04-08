using Microsoft.AspNetCore.Mvc;
using users_crud.Model;
using users_crud.Repository;

namespace users_crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var users = await _repository.ListUsers();
            return users.Any()
                ? Ok(users)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repository.FindUserById(id);
            return user != null
                ? Ok(user)
                : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.CreateUser(user);
            return await _repository.SaveChangesAsync()
                ? Ok("Usuário adicionado com sucesso")
                : BadRequest("Erro ao salvar o usuário");
        }
    }
}