namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public interface IFinishable : IProgressable
    {
        public bool Finished { get; set; }
    }
}
