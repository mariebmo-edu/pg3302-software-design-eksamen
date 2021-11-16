using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class MenuHandler
    {
        // Skal brukes i UI av en menu/view-klasse

        private IProgressable Progressable { get; set; }
        public List<IProgressable> Options { get; set; } = new();
        public bool IsFinishable { get; }

        public MenuHandler chooseOption(string input)
        {
            int convertedInput = Int32.Parse(input);

            if (input.ToLower().Equals("e"))
            {
                Quit();
            }

            if (input.ToLower().Equals("f") && (Progressable is Lecture || Progressable is Task))
            {
                setFinished();
            }

            if (convertedInput == 1 || convertedInput <= Options.Count)
            {
                return MenuHandlerFactory.MakeMenuHandler(Options[convertedInput-1]);
            }

            if (convertedInput > Options.Count)
            {
                GetErrorMessage();
            }

            return this;

        }

        public MenuHandler(IProgressable progressable, bool isFinishable)
        {
            Progressable = progressable;
            IsFinishable = isFinishable;
        }

        public MenuHandler Quit()
        {
            Console.WriteLine("Vil du avslutte? [J/N]");
            string quitInput = Console.ReadLine().ToLower();
            if (!quitInput.Equals("j"))
            {
                return this;
            }
            // terminate program
            return null;
        }

        public MenuHandler GetErrorMessage()
        {
            // error message
            Console.WriteLine("Velg et alternativ mellom 0 og " + Options.Count + ", eller E");
            return this;
        }

        public MenuHandler setFinished()
        {
            // må muligens implementeres på en annen måte

            IFinishable f = Progressable as IFinishable;
            f.Finished = !f.Finished;
            Progressable = f;
            string finished;
            if (f.Finished)
            {
                finished = "ferdig!";
            }
            else
            {
                finished = "uferdig!";
            }
            // mulig denne aldri blir synlig
            Console.WriteLine(f.Title + " satt som " + finished);
            return this;
        }
    }
}
