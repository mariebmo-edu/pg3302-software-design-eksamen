using System;
using System.Text;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class MenuPrinter<T>
    {
        public void ShowMenu(IPrintable<T> printable)
        {
            if (printable is OptionsHandler)
            {
                OptionsHandler oh = printable as OptionsHandler;
                
                Console.WriteLine(oh.Progressable.Title);

                IProgressionHandler<IProgressable> ph = ProgressionHandlerFactory.MakeProgressionHandler(oh.Progressable);
                ProgressionWrapper pw = ph.GetProgression();
                Console.WriteLine(ProgressionBarHandler.GenerateProgressBar(pw));

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
                    menuOptionsString.Append("["+(i+1)+"] - ");
                    menuOptionsString.Append(oh.Options[i].Title+"\n");
                }

                if (oh.SuperOption != null)
                {
                    menuOptionsString.Append("\n[0] - Tilbake til " + oh.SuperOption.Progressable.Title);
                }
                
                Console.WriteLine(menuOptionsString.ToString());
            }
            // else if (printable is LoginMenu)
            {
            }
            Console.WriteLine("\n[E] - Avslutt");
        }
    }
}