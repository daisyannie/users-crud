using Microsoft.AspNetCore.Mvc;
using users_crud.Model;
using users_crud.Repository;
using users_crud.UseCases;

namespace users_crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly CreateUser _createUserUseCase;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
            _createUserUseCase = new CreateUser(repository);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _repository.ListUsers();
            return users.Any()
                ? Ok(users)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.FindUserById(id);
            return user != null
                ? Ok(user)
                : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            return await _createUserUseCase.Create(user)
                ? Ok("Usuário adicionado com sucesso")
                : BadRequest("Erro ao salvar o usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            var existingUser = await _repository.FindUserById(id);
            if(existingUser == null) return NotFound("Usuário não encontrado");

            existingUser.Name = user.Name ?? existingUser.Name;
            existingUser.DateBirth = user.DateBirth != new DateTime()
            ? user.DateBirth : existingUser.DateBirth;

            _repository.UpdateUser(existingUser);
            return await _repository.SaveChangesAsync()
                ? Ok("Usuário atualizado com sucesso")
                : BadRequest("Erro ao atualizar o usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUser = await _repository.FindUserById(id);
            if(existingUser == null) return NotFound("Usuário não encontrado");

            _repository.DeleteUser(existingUser);
            return await _repository.SaveChangesAsync()
                ? Ok("Usuário excluído com sucesso")
                : BadRequest("Erro ao excluir o usuário");
        }
    }
}