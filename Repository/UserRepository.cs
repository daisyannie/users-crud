using Microsoft.EntityFrameworkCore;
using users_crud.Data;
using users_crud.Model;

namespace users_crud.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChangesAsync();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<User>> ListUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindUserById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}