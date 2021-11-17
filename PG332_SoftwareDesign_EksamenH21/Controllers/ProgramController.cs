using System;
using System.Formats.Asn1;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21.Controllers
{
    public class ProgramController
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
            do
            {
                MenuPrinter.ShowMenu(_printable);
                _printable = _printable.ChooseOption(Reader.ReadLine());
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
    }
}