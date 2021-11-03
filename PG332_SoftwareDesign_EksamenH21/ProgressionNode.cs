namespace PG332_SoftwareDesign_EksamenH21
{
    public class ProgressionNode : IProgression
    {
        public bool Published { get; set; }
        public bool Finished { get; set; }

        public double GetProgression()
        {
            if (Published && Finished)  // Tror vi må ha (published && finished) her for å få det riktig, men det kan kanskje diskuteres
            {
                return 1.00;
            }
            else
            {
                return 0.00;
            }
        }

        public ProgressionNode()
        {
            Published = false;
            Finished = false;
        }
    }
}