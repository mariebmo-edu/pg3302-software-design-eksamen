using System.Collections.Generic;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class TaskSet
    {
        public long Id { get; set; }
        private List<Task> Tasks { get; set; }
        private IProgression Progression { get; set; }
    }
}