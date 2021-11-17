using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class MenuPrinter<T>
    {
        public void ShowMenu(IPrintable<T> printable)
        {
            if (printable is OptionsHandler)
            {
                OptionsHandler oh = printable as OptionsHandler;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(WriteLine());
                Console.WriteLine(CenteredHeader(oh));
                Console.WriteLine(WriteLine());
                Console.ForegroundColor = ConsoleColor.Gray;
                WriteColourInProgressString("#:fullført, =:publisert, -:ikke publisert");                
                Console.WriteLine(WriteLine());


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
                    menuOptionsString.Append("\n[0] - Tilbake til " + oh.SuperOption.Progressable.Title);
                }

                Console.WriteLine(menuOptionsString.ToString());
            }

            Console.WriteLine("\n[E] - Avslutt");
        }


        public string AskForEmail()
        {
            Console.WriteLine("Vennligst skriv inn din e-post:");
            return Console.ReadLine();
        }

        public string AskForPassword()
        {
            Console.WriteLine("Vennligst skriv inn ditt passord:");
            return Console.ReadLine();
        }

        public void ErrorWithAuthentication()
        {
            Console.Clear();
            Logger.Instance.Write("Error with authentication");
            Console.WriteLine("Feil e-post eller passord. Prøv igjen.");
        }

        public void WelcomeMessage(string fullName)
        {
            Console.Clear();
            Console.WriteLine($"Velkommen {fullName}. Her er dine menyvalg:");
        }

        public string WriteLine()
        {
            return "------------------------------------------";
        }

        private string CenteredHeader(OptionsHandler oh)
        {

            StringBuilder sb = new();

            for (int i = 0; i < (WriteLine().Length - oh.Progressable.Title.Length) / 2; i++)
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