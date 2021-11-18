using System;
using System.Text;
using System.Text.RegularExpressions;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;

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
            else if (printable is LoginMessageWrapper)
            {
                LoginMessageWrapper loginMessage = printable as LoginMessageWrapper;
                Console.WriteLine(loginMessage.Message);
                Console.WriteLine("Trykk enter for å fortsette");
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
                
                string finishType = "THIS";
                string finishedString = "FINISHED";

                if (f is Course)
                {
                    finishType = "eksamen";
                    finishedString = "bestått";
                }
                else if (f is Lecture)
                {
                    finishType = "forelesning";
                    finishedString = "sett";
                }
                else if (f is Task)
                {
                    finishType = "oppgave";
                    finishedString = "gjort";
                }
                
                menuOptionsString.Append($"\n[F] - Sett {finishType} som ");
                if (!f.Finished)
                {
                    menuOptionsString.Append($"{finishedString}\n");
                }
                else
                {
                    menuOptionsString.Append($"ikke {finishedString}\n");
                }
            }

            menuOptionsString.Append("\n");
            
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