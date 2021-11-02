using System.Collections.Generic;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class ProgressionComposite : IProgression
    {
        public double Total { get; set; }
        public bool Published { get; set; }
        public double Finished { get; set; }
        public Array<IProgression> Children { get; set; }

        public Array<IProgression> ListChildren()
        {
            return null;
        }

        public double GetProgression()
        {
            double returnValue = 0.00;

            if (published)
            {
                for (IProgression Child :
                Children)
                {
                    if (Child.Published)
                    {
                        returnValue = returnValue + Child.GetProgression();
                    }
                }
            }

            return returnValue / Total;
        }

        public ProgressionComposite(int TotalChildren)
        {
            if (TotalChildren < 1)
            {
                throw new ArgumentOutOfRangeException("TotalChildren must be over 0");
            }
            Total = TotalChildren;
            Published = false;
            Finished = 0.00;
            Children = new IProgression[TotalChildren];
        }
    }
}