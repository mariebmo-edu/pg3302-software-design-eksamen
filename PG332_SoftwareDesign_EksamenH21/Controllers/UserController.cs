using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using PG332_SoftwareDesign_EksamenH21.Stubs;

namespace PG332_SoftwareDesign_EksamenH21.Controllers
{
    public class UserController
    {
        public IUserDao UserDao { get; set; }
        public UserViewStub UserView { get; set; }

        public UserController()
        {
            UserDao = new UserDao();
            UserView = new UserViewStub();
        }

    
        public string GetUserById(string id)
        {
            var userObject = UserDao.RetrieveById(int.Parse(id));
            var viewModel = UserView.UserModelView(userObject);
            return viewModel;
        }

        public string RegisterNewUser()
        {
            var user = new User();
            // Input skal endres til Console.Readline()
            user.FirstName = "Martin";
            user.LastName = "Gregersen";
            user.Email = "gogo@gmail.com";
            user.PhoneNumber = "55555555";
            //...
            UserDao.Save(user);
            var viewModel = UserView.UserModelView(user);
            return $"Added: {viewModel}";
        }
        
        
    }
}