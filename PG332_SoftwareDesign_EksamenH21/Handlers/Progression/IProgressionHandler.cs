﻿using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers.Progression
{
    public interface IProgressionHandler<T> where T : IProgressable
    {
        public ProgressionWrapper ProgressionWrapper { get; set; }

        public ProgressionWrapper GetProgression();
    }
}
