﻿using System;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Handlers.Printable;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21.Controllers
{
    public class ProgramController : IController
    {
        private User User { get; set; }
        private ConsolePrinter ConsolePrinter { get; } = new();
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
                ConsolePrinter.ShowMenu(_printable);
                _printable = _printable.ChooseOption(Reader.ReadLine());
                Console.Clear();
                if (_printable is OptionsWrapper) SaveUpdates();
            }
        }

        private void SaveUpdates()
        {
            IUserDao dao = new UserDao();
            if (_printable is OptionsWrapper {Publishable: User user})
            {
                User = user;
            }

            dao.Update(User);
        }
    }
}