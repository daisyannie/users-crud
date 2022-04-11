using users_crud.Model;
using users_crud.Repository;
using users_crud.UseCases;
using Xunit;

namespace users_crud.Tests
{
    public class DeleteUserTest
    {
        [Fact]
        public async void DeleteTest() {
            var user = new User();
            user.Id = 1;
            user.Name = "Test User";
            user.DateBirth = new DateTime(2021, 10, 01);

            var memoryRepository = new MemoryUserRepository();
            
            var createUser = new CreateUser(memoryRepository);
            await createUser.Create(user);

            var subject = new DeleteUser(memoryRepository);
            await subject.Delete(user.Id);

            var listUsers = new ListUsers(memoryRepository);
            var results = await listUsers.List();

            Assert.DoesNotContain<User>(user, results);
        }
        
    }
}