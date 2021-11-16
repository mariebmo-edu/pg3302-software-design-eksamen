using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class OptionsHandler
    {
        // Skal brukes i UI av en menu/view-klasse

        private IProgressable Progressable { get; set; }
        public List<IProgressable> Options { get; private set; } = new();
        public OptionsHandler SuperOptions { get; private set; }
        public bool IsFinishable { get; private set; }

        public OptionsHandler(IProgressable progressable, OptionsHandler superOptions, bool isFinishable)
        {
            Progressable = progressable;
            SuperOptions = superOptions;
            IsFinishable = isFinishable;
        }
        
        public OptionsHandler ChooseOption(string input)
        {
            if (input.ToLower().Equals("e"))
            {
                return Quit();
            }

            if (input.ToLower().Equals("f") && IsFinishable)
            {
                return SetFinished();
            }

            int convertedInput;
            
            if (!Int32.TryParse(input, out convertedInput))
            {
                return GetErrorMessage();
            };

            if (convertedInput >= 0 && convertedInput <= Options.Count)
            {
                return GetOption(convertedInput);
            }

            if (convertedInput > Options.Count)
            {
                return GetErrorMessage();
            }

            return this;

        }

        private OptionsHandler GetOption(int convertedInput)
        {
            if (convertedInput == 0)
            {
                return SuperOptions;
            }
            
            if (Options[convertedInput - 1].Published)
            {
                return OptionsHandlerFactory.MakeMenuHandler(Options[convertedInput - 1], this);
            }
                
            Console.WriteLine("Dette menyvalget er ikke publisert");
            Console.WriteLine("Trykk en tast for å gå videre");
            Logger.Instance.Write("UNPUBLISHED OPTION");
            Console.ReadKey();
            
            return this;
        }
        
        private OptionsHandler Quit()
        {
            Console.WriteLine("Vil du avslutte? [J/N]");
            string quitInput = Console.ReadLine()?.ToLower();
            
            if (quitInput != null && !quitInput.Equals("j"))
            {
                return this;
            }
            
            Console.WriteLine("På gjensyn!");
            Console.WriteLine("Trykk en tast for å avslutte");
            Logger.Instance.Write("EXITING APPLICATION");
            Console.ReadKey();
            
            Environment.Exit(0);
            
            return null;
        }

        private OptionsHandler GetErrorMessage()
        {
            Console.WriteLine("Velg et menyalternativ.");
            Console.WriteLine("Trykk en tast for å gå videre");
            Logger.Instance.Write("PEBKAC");
            Console.ReadKey();
            
            return this;
        }

        private OptionsHandler SetFinished()
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
            Logger.Instance.Write(f.Title + " FINISHED BOOL TOGGLED");
            Console.ReadKey();
            
            return this;
        }
    }
}
