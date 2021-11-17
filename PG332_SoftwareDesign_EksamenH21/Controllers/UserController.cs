using System;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21.Controllers
{
    public class UserController
    {
        public User User { get; set; }
        private IPrintable _printable;
        private MenuPrinter MenuPrinter { get; set; } = new();
        private UserAuthenticator _userAuthenticator = new();
        
        public void Start()
        {
            //User = _userAuthenticator.Authenticate();
            //MenuPrinter.WelcomeMessage(GetFullName());
            
            
            Menu();
        }

        private void Menu()
        {
            _printable = new EmailQuestionWrapper();

            do
            {
                MenuPrinter.ShowMenu(_printable);
                _printable = _printable.ChooseOption(Console.ReadLine());
                Console.Clear();
                if (_printable is OptionsWrapper) SaveUpdates();
            } while (_printable != null);
        }

        private void SaveUpdates()
        {
            IUserDao dao = new UserDao();
            OptionsWrapper printable = _printable as OptionsWrapper;
            if (printable.Progressable is User)
            {
                User = printable.Progressable as User;
            }
            dao.Update(User);
        }

        public string GetFullName()
        {
            return $"{User.FirstName} {User.LastName}";
        }
    }
}