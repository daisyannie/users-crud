using users_crud.Model;

namespace users_crud.Repository
{
    public class MemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public MemoryUserRepository()
        {
            _users = new List<User>();
        }
        public void CreateUser(User user)
        {
            _users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }
        public async Task<IEnumerable<User>> ListUsers()
        {
            return _users;
        }

        public async Task<User?> FindUserById(int id)
        {
            return _users.Where(x => x.Id == id).FirstOrDefault<User>();
        }


        public void UpdateUser(User user)
        {
            var existingUser = _users.Where(x => x.Id == user.Id).FirstOrDefault<User>();
            if (existingUser == null) return;

            existingUser.DateBirth = user.DateBirth;
            existingUser.Name = user.Name;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return true;
        }
    }
}