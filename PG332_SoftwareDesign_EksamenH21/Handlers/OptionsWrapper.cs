using System;
using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class OptionsWrapper : IPrintable
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
        public IPrintable SuperOption { get; set; }
        public bool IsFinishable { get; private set; }

        #endregion

        #region Constructor

        public OptionsWrapper(IProgressable progressable, OptionsWrapper superOption, bool isFinishable)
        {
            Progressable = progressable;
            SuperOption = superOption;
            IsFinishable = isFinishable;
        }

        #endregion

        #region Public methods

        public IPrintable ChooseOption(string input)
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
                Logger.Instance.Write($"TRYPARSE FAILED AT {Progressable.Title}");
                return new ErrorMessageWrapper("Velg et gyldig menyalternativ", this);
            }

            if (convertedInput >= 0 && convertedInput <= Options.Count)
            {
                return GetOption(convertedInput);
            }

            if (convertedInput > Options.Count)
            {
                Logger.Instance.Write($"INDEX OUT OF RANGE AT {Progressable.Title}");
                return new ErrorMessageWrapper("Velg et gyldig menyalternativ", this);
            }

            return this;
        }

        #endregion

        #region Private methods

        private IPrintable GetOption(int convertedInput)
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

            Logger.Instance.Write($"UNPUBLISHED OPTION {Options[convertedInput-1].Title} CHOSEN");
            return new ErrorMessageWrapper("Dette menyvalget er ikke publisert", this);
        }

        private IPrintable Quit()
        {
            return new QuitQuestionWrapper(this);
        }

        private IPrintable SetFinished()
        {
            IFinishable f = Progressable as IFinishable;
            f.Finished = !f.Finished;
            Progressable = f;
            
            Logger.Instance.Write($"{f.Title} SET AS {f.Finished}");
            return this;
        }

        #endregion

        #region Overridden methods

        protected bool Equals(OptionsWrapper other)
        {
            return Equals(Progressable, other.Progressable) && Equals(Options, other.Options) &&
                   Equals(SuperOption, other.SuperOption) && IsFinishable == other.IsFinishable;
        }

        public static bool operator ==(OptionsWrapper left, OptionsWrapper right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OptionsWrapper left, OptionsWrapper right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OptionsWrapper) obj);
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