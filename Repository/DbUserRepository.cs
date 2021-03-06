using Microsoft.EntityFrameworkCore;
using users_crud.Data;
using users_crud.Model;

namespace users_crud.Repository
{
    public class DbUserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public DbUserRepository(UserContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }
        public async Task<IEnumerable<User>> ListUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> FindUserById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public void UpdateUser(User user)
        {
            _context.Update(user);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}