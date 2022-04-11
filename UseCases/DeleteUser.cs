using users_crud.Model;
using users_crud.Repository;

namespace users_crud.UseCases
{
    public class DeleteUser
    {
        private readonly IUserRepository _repository;

        public DeleteUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id) {
            var existingUser = await _repository.FindUserById(id);
            if(existingUser == null) return false;

            _repository.DeleteUser(existingUser);
            return await _repository.SaveChangesAsync();
        }
    }
}