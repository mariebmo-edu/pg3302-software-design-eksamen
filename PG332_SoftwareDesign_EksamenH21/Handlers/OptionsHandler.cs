using System;
using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class OptionsHandler : IPrintable<IProgressable>
    {
        #region Documentation
            // Skal brukes i UI av en menu/view-klasse

            // BRUK OptionsHandlerFactory FOR Å GENERERE INSTANSER! Alt er automatisert der

            // Progressable property er nivået man er på (f.eks. Lecture)

            // Options property skal brukes for å printe menyvalg i konsollen (f.eks. alle Lectures i et Course)

            // SuperOption er den overordnede menyen (f.eks. hvis man er på et Course, er et spesifikt Semester SuperOption)
            // Hvis SuperOption er null, skal det ikke printes menyvalg for dette (gjelder nå bare på User-nivå)

            // IsFinishable property brukes for å generere menyvalg for å sette en Lecture/Task som Finished

            // OBS! Vi må generere meny på User-nivå FØR vi viser semestermenyen brukeren skal starte på!
            // Ellers vil det ikke genereres SuperOption automatisk på Semester!
            
        #endregion
        
        #region Properties

            public IProgressable Progressable { get; set; }
            public List<IProgressable> Options { get; set; } = new();
            public OptionsHandler SuperOption { get; set; }
            public bool IsFinishable { get; private set; }

        #endregion

        #region Constructor

            public OptionsHandler(IProgressable progressable, OptionsHandler superOption, bool isFinishable)
            {
                Progressable = progressable;
                SuperOption = superOption;
                IsFinishable = isFinishable;
            }

        #endregion

        #region Public methods

            public IPrintable<IProgressable> ChooseOption(string input)
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
                }

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

        #endregion

        #region Private methods

            private OptionsHandler GetOption(int convertedInput)
            {
                if (convertedInput == 0 && SuperOption != null)
                {
                    return SuperOption;
                }

                if (convertedInput == 0 && SuperOption == null)
                {
                    return this;
                }

                if (Options[convertedInput - 1].Published)
                {
                    return OptionsHandlerFactory.MakeOptionsHandler(Options[convertedInput - 1], this);
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
                Console.WriteLine("Velg et gyldig menyalternativ.");
                Console.WriteLine("Trykk en tast for å gå videre");
                Logger.Instance.Write("PEBKAC");
                Console.ReadKey(); // Kommenter ut for tester

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
                Console.ReadKey(); // Kommenter ut for tester

                return this;
            }

        #endregion

        #region Overridden methods

        protected bool Equals(OptionsHandler other)
            {
                return Equals(Progressable, other.Progressable) && Equals(Options, other.Options) &&
                       Equals(SuperOption, other.SuperOption) && IsFinishable == other.IsFinishable;
            }

            public static bool operator ==(OptionsHandler left, OptionsHandler right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(OptionsHandler left, OptionsHandler right)
            {
                return !Equals(left, right);
            }

            public override bool Equals(object? obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((OptionsHandler) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Progressable, Options, SuperOption, IsFinishable);
            }

            public override string ToString()
            {
                string returnedString = GetType() + "\n" +
                                        Progressable.GetType() + Progressable.GetHashCode() + "\n" +
                                        Options.GetType() + Options.GetHashCode() + "\n" +
                                        SuperOption.GetType() + SuperOption.GetHashCode() + "\n" +
                                        IsFinishable.GetType() + IsFinishable.GetHashCode();
                return returnedString;
            }

        #endregion

    }
}