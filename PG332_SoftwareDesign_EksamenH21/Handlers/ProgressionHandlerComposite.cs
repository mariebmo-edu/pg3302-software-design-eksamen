using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionHandlerComposite : IProgressionHandler<IProgressable>
    {
        public IProgressable Progressable { get; }

        public List<IProgressionHandler<IProgressable>> Children = new();
        public ProgressionWrapper ProgressionWrapper { get; set; }

        public ProgressionHandlerComposite(IProgressable progressable)
        {
            Progressable = progressable;
        }

        public double GetPublishedPercent()
        {
            double returnValue = 0.00;

            if (!Progressable.Published)
            {
                return returnValue;
            }

            foreach (var c in Children)
            {
                returnValue += c.GetPublishedPercent();
            }

            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }

        public double GetFinishedPercent()
        {
            double returnValue = 0.00;

            if (!Progressable.Published)
            {
                return returnValue;
            }

            foreach (var c in Children)
            {
                returnValue += c.GetFinishedPercent();
            }

            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }

        public ProgressionWrapper GetProgression()
        {
            if (!Progressable.Published)
            {
                return new ProgressionWrapper(0.00, 0.00);
            }

            if (!(ProgressionWrapper == null))
            {
                return ProgressionWrapper / Children.Count;
            }

            ProgressionWrapper = new(0.00, 0.00);

            foreach (var c in Children)
            {
                ProgressionWrapper = ProgressionWrapper + c.GetProgression();
            }
            
            return ProgressionWrapper / Children.Count;
        }
    }
}
