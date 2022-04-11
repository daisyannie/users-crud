using users_crud.Model;
using users_crud.Repository;
using users_crud.UseCases;
using Xunit;

namespace users_crud.Tests
{
    public class CreateUserTest
    {
        [Fact]
        public async void CreateTest() {
            var user = new User();
            user.Id = 1;
            user.Name = "Test User";
            user.DateBirth = new DateTime(2021, 10, 01);

            var memoryRepository = new MemoryUserRepository();
            
            var subject = new CreateUser(memoryRepository);
            await subject.Create(user);

            var listUsers = new ListUsers(memoryRepository);
            var results = await listUsers.List();

            Assert.Contains<User>(user, results);
        }
        
    }
}