using users_crud.Model;
using users_crud.Repository;

namespace users_crud.UseCases
{
    public class ListUsers
    {
        private readonly IUserRepository _repository;

        public ListUsers(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> List() {
            return await _repository.ListUsers();
        }
    }
}