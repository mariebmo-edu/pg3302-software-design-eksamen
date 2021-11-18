using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using static BCrypt.Net.BCrypt;

namespace PG332_SoftwareDesign_EksamenH21.util
{
    public static class UserAuthenticator
    {
        public static User Authenticate(string email, string password)
        {
            UserDao dao = new ();
            var retrieveByEmail = dao.RetrieveByEmail(email);
            if (retrieveByEmail is null) return null;

            return Verify(password, retrieveByEmail.Password) ? retrieveByEmail : null;
        }
    }
}