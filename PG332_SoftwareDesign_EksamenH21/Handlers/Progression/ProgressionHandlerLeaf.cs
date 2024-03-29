﻿using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers.Progression
{
    public class ProgressionHandlerLeaf : IProgressionHandler<IProgressable>
    {
        private IPublishable Progressable { get; }
        public ProgressionWrapper ProgressionWrapper { get; set; }

        public ProgressionHandlerLeaf(IPublishable progressable)
        {
            Progressable = progressable;
        }

        private double GetPublishedPercent()
        {
            return Progressable.Published ? 1.00 : 0.00;
        }

        private double GetFinishedPercent()
        {
            IFinishable finishable = Progressable as IFinishable;

            return finishable is {Published: true, Finished: true} ? 1.00 : 0.00;
        }

        public ProgressionWrapper GetProgression()
        {
            if (ProgressionWrapper != null) return ProgressionWrapper;
            ProgressionWrapper = new ProgressionWrapper(GetPublishedPercent(), GetFinishedPercent());
            return ProgressionWrapper;
        }
    }
}