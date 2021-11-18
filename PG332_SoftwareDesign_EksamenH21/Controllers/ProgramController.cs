using System;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21.Controllers
{
    public class ProgramController : IController
    {
        public User User { get; set; }
        private MenuPrinter MenuPrinter { get; } = new();
        private IPrintable _printable;
        private IReader Reader { get; }


        public ProgramController(IReader reader)
        {
            Reader = reader;
        }

        public void Start()
        {
            _printable = new EmailQuestionWrapper();
            while (_printable != null)
            {
                MenuPrinter.ShowMenu(_printable);
                _printable = _printable.ChooseOption(Reader.ReadLine());
                Console.Clear();
                if (_printable is OptionsWrapper) SaveUpdates();
            }
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
    }
}