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
        private readonly UpdateUser _updateUserUseCase;
        private readonly ListUsers _listUsersUseCase;
        private readonly FindUser _findUserUseCase;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
            _createUserUseCase = new CreateUser(repository);
            _updateUserUseCase = new UpdateUser(repository);
            _listUsersUseCase = new ListUsers(repository);
            _findUserUseCase = new FindUser(repository);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _listUsersUseCase.List();
            return users.Any()
                ? Ok(users)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _findUserUseCase.Find(id);
            return user != null
                ? Ok(user)
                : NotFound();
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
            return await _updateUserUseCase.Update(id, user)
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