namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public interface IPublishable : IProgressable
    {
        public bool Published { get; set; }
    }
}
