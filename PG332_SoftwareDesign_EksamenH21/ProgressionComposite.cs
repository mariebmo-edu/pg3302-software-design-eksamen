using System.Collections.Generic;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class ProgressionComposite
    {
        public double Total { get; set; }
        public bool Published { get; set; }
        public double Finished { get; set; }
        public List<IProgression> Children { get; set; }

        public List<IProgression> ListChildren()
        {
            return null;
        }

    }
}