using users_crud.Model;
using users_crud.Repository;

namespace users_crud.UseCases
{
    public class CreateUser
    {
        private readonly IUserRepository _repository;

        public CreateUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(User user) {
            _repository.CreateUser(user);
            return await _repository.SaveChangesAsync();
        }
    }
}