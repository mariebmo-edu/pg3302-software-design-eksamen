using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class MenuPrinter
    {
        public void ShowMenu(IPrintable printable)
        {
            if (printable is OptionsWrapper)
            {
                ShowProgressableMenu(printable);
            } 
            else if (printable is ErrorMessageWrapper)
            {
                ErrorMessageWrapper errorMessage = printable as ErrorMessageWrapper;
                Console.WriteLine(errorMessage.ErrorMessage);
                Console.WriteLine("Trykk enter for å fortsette");
            }
            else if (printable is EmailQuestionWrapper)
            {
                Console.WriteLine("Skriv inn epost:");
            }
            else if (printable is PasswordQuestionWrapper)
            {
                Console.WriteLine("Skriv inn passord:");
            }
            else if (printable is MessageWrapper)
            {
                MessageWrapper message = printable as MessageWrapper;
                Console.WriteLine(message.Message);
            }
            else if (printable is QuitQuestionWrapper)
            {
                Console.WriteLine("Ønsker du å avslutte? [J/N]");
            }
            else if (printable is QuitMessageWrapper)
            {
                Console.WriteLine("På gjensyn!");
                Console.WriteLine("Trykk enter for å avslutte");
            }
        }

        private void ShowProgressableMenu(IPrintable printable)
        {
            OptionsWrapper oh = printable as OptionsWrapper;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ReturnLine());
            Console.WriteLine(CenteredHeader(oh));
            Console.WriteLine(ReturnLine());
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteColourInProgressString("#:fullført, =:publisert, -:ikke publisert");
            Console.WriteLine(ReturnLine());


            IProgressionHandler<IProgressable> ph = ProgressionHandlerFactory.MakeProgressionHandler(oh.Progressable);
            ProgressionWrapper pw = ph.GetProgression();
            ConsoleColor defaultColor = Console.ForegroundColor;
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine(ProgressionBarHandler.GenerateProgressBar(pw));
            //Console.ForegroundColor = defaultColor;
            WriteColourInProgressString(ProgressionBarHandler.GenerateProgressBar(pw));
            StringBuilder menuOptionsString = new();

            if (oh.IsFinishable)
            {
                IFinishable f = oh.Progressable as IFinishable;
                menuOptionsString.Append("[F] - Sett som ");
                if (!f.Finished)
                {
                    menuOptionsString.Append("ferdig\n");
                }
                else
                {
                    menuOptionsString.Append("uferdig\n");
                }
            }

            for (int i = 0; i < oh.Options.Count; i++)
            {
                menuOptionsString.Append("[" + (i + 1) + "] - ");
                menuOptionsString.Append(oh.Options[i].Title + "\n");
            }

            if (oh.SuperOption != null)
            {
                OptionsWrapper super = oh.SuperOption as OptionsWrapper;
                menuOptionsString.Append("\n[0] - Tilbake til " + super.Progressable.Title);
            }

            Console.WriteLine(menuOptionsString.ToString());
            Console.WriteLine("\n[E] - Avslutt");
        }


        // public string AskForEmail()
        // {
        //     Console.WriteLine("Vennligst skriv inn din e-post:");
        //     return Console.ReadLine();
        // }
        //
        // public string AskForPassword()
        // {
        //     Console.WriteLine("Vennligst skriv inn ditt passord:");
        //     return Console.ReadLine();
        // }
        //
        // public void ErrorWithAuthentication()
        // {
        //     Console.Clear();
        //     Logger.Instance.Write("Error with authentication");
        //     Console.WriteLine("Feil e-post eller passord. Prøv igjen.");
        // }
        //
        // public void WelcomeMessage(string fullName)
        // {
        //     Console.Clear();
        //     Console.WriteLine($"Velkommen {fullName}. Her er dine menyvalg:");
        // }

        private string ReturnLine()
        {
            return "------------------------------------------";
        }

        private string CenteredHeader(OptionsWrapper oh)
        {

            StringBuilder sb = new();

            for (int i = 0; i < (ReturnLine().Length - oh.Progressable.Title.Length) / 2; i++)
            {
                sb.Append(' ');
            }

            return sb.ToString() + oh.Progressable.Title;
        }

        private void WriteColourInProgressString(string message)
        {
            string[] sections = Regex.Split(message, "(#*)(=*)(-*)");

            for (int i = 0; i < sections.Length; i++)
            {
                if (sections[i].Contains("#"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                }
                else if (sections[i].Contains("="))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write(sections[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}