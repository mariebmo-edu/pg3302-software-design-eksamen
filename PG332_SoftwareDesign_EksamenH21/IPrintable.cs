using System.Collections.Generic;

namespace PG332_SoftwareDesign_EksamenH21
{
    public interface IPrintable<T>
    {
        List<T> Options { get; set; }
        public IPrintable<T> ChooseOption(string input);
    }
}