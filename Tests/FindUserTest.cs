using users_crud.Model;
using users_crud.Repository;
using users_crud.UseCases;
using Xunit;

namespace users_crud.Tests
{
    public class FindUserTest
    {
        [Fact]
        public async void FindTest() {
            var user = new User();
            user.Id = 1;
            user.Name = "Test User";
            user.DateBirth = new DateTime(2021, 10, 01);

            var memoryRepository = new MemoryUserRepository();
            
            var createUser = new CreateUser(memoryRepository);
            await createUser.Create(user);

            var subject = new FindUser(memoryRepository);
            var result = await subject.Find(user.Id);

            Assert.Equal<User>(user, result);
        }
        
    }
}