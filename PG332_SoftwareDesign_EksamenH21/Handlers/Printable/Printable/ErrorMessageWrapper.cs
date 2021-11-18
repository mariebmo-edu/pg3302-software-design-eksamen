using System;

namespace PG332_SoftwareDesign_EksamenH21.Handlers.Printable
{
    public class ErrorMessageWrapper : IPrintableWithSuper
    {
        public IPrintable SuperOption { get; set; }
        public string ErrorMessage { get; }
        
        public ErrorMessageWrapper(string errorMessage, IPrintable superOption)
        {
            ErrorMessage = errorMessage;
            SuperOption = superOption;
        }
        
        public IPrintable ChooseOption(string input)
        {
            return SuperOption;
        }

        protected bool Equals(ErrorMessageWrapper other)
        {
            return Equals(SuperOption, other.SuperOption) && ErrorMessage == other.ErrorMessage;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ErrorMessageWrapper) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SuperOption, ErrorMessage);
        }

        public static bool operator ==(ErrorMessageWrapper left, ErrorMessageWrapper right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ErrorMessageWrapper left, ErrorMessageWrapper right)
        {
            return !Equals(left, right);
        }
    }
}