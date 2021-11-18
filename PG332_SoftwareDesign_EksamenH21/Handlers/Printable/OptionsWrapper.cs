using System;
using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21.Handlers.Printable
{
    public class OptionsWrapper : IPrintableWithSuper
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

        public IProgressable Publishable { get; set; }
        public List<IPublishable> Options { get; set; } = new();
        public IPrintable SuperOption { get; set; }
        public bool IsFinishable { get; private set; }

        #endregion

        #region Constructor

        public OptionsWrapper(IProgressable publishable, OptionsWrapper superOption, bool isFinishable)
        {
            Publishable = publishable;
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
                Logger.Write($"TRYPARSE FAILED AT {Publishable.Title}");
                return new ErrorMessageWrapper("Velg et gyldig menyalternativ", this);
            }

            if (convertedInput >= 0 && convertedInput <= Options.Count)
            {
                return GetOption(convertedInput);
            }

            if (convertedInput > Options.Count)
            {
                Logger.Write($"INDEX OUT OF RANGE AT {Publishable.Title}");
                return new ErrorMessageWrapper("Velg et gyldig menyalternativ", this);
            }

            return this;
        }

        #endregion

        #region Private methods

        private IPrintable GetOption(int convertedInput)
        {
            switch (convertedInput)
            {
                case 0 when SuperOption != null:
                    return SuperOption;
                case 0 when SuperOption == null:
                    return this;
            }

            if (Options[convertedInput - 1].Published)
            {
                return OptionsWrapperFactory.MakeOptionsWrapper(Options[convertedInput - 1], this);
            }

            Logger.Write($"UNPUBLISHED OPTION {Options[convertedInput-1].Title} CHOSEN");
            return new ErrorMessageWrapper("Dette menyvalget er ikke publisert", this);
        }

        private IPrintable Quit()
        {
            return new QuitQuestionWrapper(this);
        }

        private IPrintable SetFinished()
        {
            var f = Publishable as IFinishable;
            f.Finished = !f.Finished;
            Publishable = f;
            
            Logger.Write($"{f.Title} SET AS {f.Finished}");
            return this;
        }

        #endregion

        #region Overridden methods

        private bool Equals(OptionsWrapper other)
        {
            return Equals(Publishable, other.Publishable) && Equals(Options, other.Options) &&
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
            return obj.GetType() == GetType() && Equals((OptionsWrapper) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Publishable, Options, SuperOption, IsFinishable);
        }

        public override string ToString()
        {
            string returnedString = GetType() + "\n" +
                                    Publishable.GetType() + Publishable.GetHashCode() + "\n" +
                                    Options.GetType() + Options.GetHashCode() + "\n" +
                                    SuperOption.GetType() + SuperOption.GetHashCode() + "\n" +
                                    IsFinishable.GetType() + IsFinishable.GetHashCode();
            return returnedString;
        }

        #endregion
    }
}