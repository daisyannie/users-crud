using users_crud.Model;
using users_crud.Repository;

namespace users_crud.UseCases
{
    public class FindUser
    {
        private readonly IUserRepository _repository;

        public FindUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User?> Find(int id) {
            return await _repository.FindUserById(id);
        }
    }
}