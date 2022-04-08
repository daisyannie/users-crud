using users_crud.Model;

namespace users_crud.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListUsers();

        Task<User?> FindUserById(int id);

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        Task<bool> SaveChangesAsync();
    }
}