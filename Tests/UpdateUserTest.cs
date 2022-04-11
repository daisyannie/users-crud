using users_crud.Model;
using users_crud.Repository;
using users_crud.UseCases;
using Xunit;

namespace users_crud.Tests
{
    public class UpdateUserTest
    {
        [Fact]
        public async void UpdateTest() {
            var user = new User();
            user.Id = 1;
            user.Name = "Test User";
            user.DateBirth = new DateTime(2021, 10, 01);

            var updatedUser = new User();
            updatedUser.Name = "Updated User Name";

            var memoryRepository = new MemoryUserRepository();
            
            var createUser = new CreateUser(memoryRepository);
            await createUser.Create(user);

            var subject = new UpdateUser(memoryRepository);
            await subject.Update(user.Id, updatedUser);

            var findUser = new FindUser(memoryRepository);
            var result = await findUser.Find(user.Id);

            Assert.Equal(result.Name, updatedUser.Name);
        }
        
    }
}