using users_crud.Model;
using users_crud.Repository;

namespace users_crud.UseCases
{
    public class UpdateUser
    {
        private readonly IUserRepository _repository;

        public UpdateUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Update(int id, User user) {
            var existingUser = await _repository.FindUserById(id);
            if(existingUser == null) return false;

            existingUser.Name = user.Name ?? existingUser.Name;
            existingUser.DateBirth = user.DateBirth != new DateTime()
            ? user.DateBirth : existingUser.DateBirth;

            _repository.UpdateUser(existingUser);
            return await _repository.SaveChangesAsync();
        }
    }
}