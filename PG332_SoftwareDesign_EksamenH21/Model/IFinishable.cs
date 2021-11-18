namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public interface IFinishable : IPublishable
    {
        public bool Finished { get; set; }
    }
}
