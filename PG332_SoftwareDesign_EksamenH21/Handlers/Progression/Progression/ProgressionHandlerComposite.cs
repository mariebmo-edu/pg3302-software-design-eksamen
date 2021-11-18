using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers.Progression
{
    public class ProgressionHandlerComposite : IProgressionHandler<IPublishable>
    {
        private IProgressable Progressable { get; }

        public List<IProgressionHandler<IPublishable>> Children = new();
        public ProgressionWrapper ProgressionWrapper { get; set; }

        public ProgressionHandlerComposite(IPublishable progressable)
        {
            Progressable = progressable;
        }

        public ProgressionWrapper GetProgression()
        {
            if (Progressable is IPublishable)
            {
                IPublishable publishable = Progressable as IPublishable;
                if (!publishable.Published)
                {
                    return new ProgressionWrapper(0.00, 0.00);
                }
            }
            
            if (ProgressionWrapper != null) return ProgressionWrapper / Children.Count;
            ProgressionWrapper = new ProgressionWrapper(0.00, 0.00);

            foreach (var c in Children)
            {
                ProgressionWrapper = ProgressionWrapper + c.GetProgression();
            }

            return ProgressionWrapper / Children.Count;
        }
    }
}