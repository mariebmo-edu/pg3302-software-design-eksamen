using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Stubs
{
    public class UserViewStub
    {
        public string UserModelView(User user)
        {
            string viewModel = user.ToString();
            return viewModel;

        }
    }
}