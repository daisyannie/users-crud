using users_crud.Model;
using users_crud.Repository;
using users_crud.UseCases;
using Xunit;

namespace users_crud.Tests
{
    public class ListUsersTest
    {
        [Fact]
        public async void ListTest() {
            var user = new User();
            user.Id = 1;
            user.Name = "Test User";
            user.DateBirth = new DateTime(2021, 10, 01);

            var user2 = new User();
            user2.Id = 2;
            user2.Name = "New Test User";
            user2.DateBirth = new DateTime(2021, 01, 05);

            var memoryRepository = new MemoryUserRepository();
            
            var createUser = new CreateUser(memoryRepository);
            await createUser.Create(user);
            await createUser.Create(user2);

            var subject = new ListUsers(memoryRepository);
            var results = await subject.List();

            Assert.Contains<User>(user, results);
            Assert.Contains<User>(user2, results);
        }
        
    }
}