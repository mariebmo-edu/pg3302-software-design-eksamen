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
        public MenuHandler SuperMenu { get; set; }
        public bool IsFinishable { get; }

        public MenuHandler(IProgressable progressable, MenuHandler superMenu, bool isFinishable)
        {
            Progressable = progressable;
            SuperMenu = superMenu;
            IsFinishable = isFinishable;
        }
        
        public MenuHandler chooseOption(string input)
        {
            int convertedInput = Int32.Parse(input);

            if (input.ToLower().Equals("e"))
            {
                Quit();
            }

            if (input.ToLower().Equals("f") && (Progressable is Lecture || Progressable is Task))
            {
                SetFinished();
            }

            if (convertedInput > 0 && convertedInput <= Options.Count)
            {
                return MenuHandlerFactory.MakeMenuHandler(Options[convertedInput-1], this);
            }

            if (convertedInput > Options.Count)
            {
                GetErrorMessage();
            }

            return this;

        }

        public MenuHandler Quit()
        {
            Console.WriteLine("Vil du avslutte? [J/N]");
            string quitInput = Console.ReadLine()?.ToLower();
            if (!quitInput.Equals("j"))
            {
                return this;
            }
            
            Console.WriteLine("På gjensyn!");
            Console.WriteLine("Trykk en tast for å gå videre");
            Console.ReadKey();
            
            // terminate program
            
            return null;
        }

        public MenuHandler GetErrorMessage()
        {
            Console.WriteLine("Velg et alternativ mellom 0 og " + Options.Count + ", eller E");
            Console.WriteLine("Trykk en tast for å gå videre");
            Console.ReadKey();
            
            return this;
        }

        public MenuHandler SetFinished()
        {
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
            
            Console.WriteLine(f.Title + " satt som " + finished);
            Console.WriteLine("Trykk en tast for å gå videre");
            Console.ReadKey();
            
            return this;
        }
    }
}
