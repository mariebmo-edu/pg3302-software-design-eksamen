using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using static BCrypt.Net.BCrypt;

namespace Test
{
    class ModelTest
    {
        [Test]
        public void UpdateUserInDB()
        {
            User user = new User()
            {
                FirstName = "Test",
                LastName = "Persson",
                Email = "test@persson.no",
                Password = HashPassword("password123")
            };

            UserDao userDao = new UserDao();
            userDao.Save(user);

            User userFromServer = userDao.RetrieveByEmail(user.Email);
            Assert.AreEqual(user, userFromServer);

            user.Email = "persson@test.no";
            userDao.Update(user);
            Assert.AreEqual("persson@test.no", user.Email);
        }
    }
}
