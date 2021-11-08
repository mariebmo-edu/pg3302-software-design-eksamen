using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class TaskSet
    {
        public long Id { get; set; }
        public long LectureId { get; private set; }
        public List<Task> Tasks { get; set; } = new();
        [NotMapped]
        public IProgression Progression { get; set; }
    }
}