using System;
using System.Text;
using System.Text.RegularExpressions;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Handlers.Printable;
using PG332_SoftwareDesign_EksamenH21.Handlers.Progression;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.util
{
    public class ConsolePrinter : IPrinter
    {
        public void ShowMenu(IPrintable printable)
        {
            switch (printable)
            {
                case OptionsWrapper:
                    ShowProgressableMenu(printable);
                    break;
                case ErrorMessageWrapper errorMessage:
                {
                    Console.WriteLine(errorMessage.ErrorMessage);
                    Console.WriteLine("Trykk enter for å fortsette");
                    break;
                }
                case EmailQuestionWrapper:
                    Console.WriteLine("Skriv inn epost:");
                    break;
                case PasswordQuestionWrapper:
                    Console.WriteLine("Skriv inn passord:");
                    break;
                case LoginMessageWrapper loginMessage:
                {
                    Console.WriteLine(loginMessage.Message);
                    Console.WriteLine("Trykk enter for å fortsette");
                    break;
                }
                case QuitQuestionWrapper:
                    Console.WriteLine("Ønsker du å avslutte? [J/N]");
                    break;
                case QuitMessageWrapper:
                    Console.WriteLine("På gjensyn!");
                    Console.WriteLine("Trykk enter for å avslutte");
                    break;
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


            IProgressionHandler<IProgressable> ph = ProgressionHandlerFactory.MakeProgressionHandler(oh.Publishable);
            ProgressionWrapper pw = ph.GetProgression();
            WriteColourInProgressString(ProgressionBarHandler.GenerateProgressBar(pw));
            StringBuilder menuOptionsString = new();

            if (oh.IsFinishable)
            {
                var f = oh.Publishable as IFinishable;
                
                var finishType = "THIS";
                var finishedString = "FINISHED";

                switch (f)
                {
                    case Course:
                        finishType = "eksamen";
                        finishedString = "bestått";
                        break;
                    case Lecture:
                        finishType = "forelesning";
                        finishedString = "sett";
                        break;
                    case Task:
                        finishType = "oppgave";
                        finishedString = "gjort";
                        break;
                }
                
                menuOptionsString.Append($"\n[F] - Sett {finishType} som ");
                menuOptionsString.Append(!f.Finished ? $"{finishedString}\n" : $"ikke {finishedString}\n");
            }

            menuOptionsString.Append('\n');
            
            for (var i = 0; i < oh.Options.Count; i++)
            {
                menuOptionsString.Append("[" + (i + 1) + "] - ");
                menuOptionsString.Append(oh.Options[i].Title);
                if (!oh.Options[i].Published)
                {
                    menuOptionsString.Append(" &(ikke publisert)&");
                }
                else
                {
                    pw = ProgressionHandlerFactory
                        .MakeProgressionHandler(oh.Options[i])
                        .GetProgression();
                    
                    menuOptionsString.Append($" &({Math.Round(pw.FinishedPercent*100, MidpointRounding.ToEven)}% ferdig)&");
                }

                menuOptionsString.Append("\n");
            }

            if (oh.SuperOption != null)
            {
                var super = oh.SuperOption as OptionsWrapper;
                menuOptionsString.Append("\n[0] - Tilbake til " + super.Publishable.Title);
            }

            WriteColorInString(menuOptionsString.ToString(), ConsoleColor.DarkGray, @"(\&.*\&)", '&');
            Console.WriteLine("\n[E] - Avslutt");
        }

        private static string ReturnLine()
        {
            return "------------------------------------------";
        }

        private static string CenteredHeader(OptionsWrapper oh)
        {

            StringBuilder sb = new();

            for (var i = 0; i < (ReturnLine().Length - oh.Publishable.Title.Length) / 2; i++)
            {
                sb.Append(' ');
            }

            return sb + oh.Publishable.Title;
        }

        private void WriteColorInString(string message, ConsoleColor color, string regex, char splitchar)
        {
            var sections = Regex.Split(message, regex);

            foreach (string section in sections)
            {
                if (section.StartsWith(splitchar) && section.EndsWith(splitchar))
                {
                    Console.ForegroundColor = color;
                    Console.Write(section.Substring(1, section.Length-2));
                    Console.ResetColor();

                }
                else
                {
                    Console.Write(section);
                }
            }
        }

        private void WriteColourInProgressString(string message)
        {
            var sections = Regex.Split(message, "(#*)(=*)(-*)");

            foreach (var section in sections)
            {
                if (section.Contains("#"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                }
                else if (section.Contains("="))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (section.Contains("-"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write(section);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}