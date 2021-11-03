using System;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Task
    {
        
        public long Id { get; set; }
        public long LectureId { get; set; }
        public Lecture Lecture { get; set; }
        public IProgression Progression { get; set; }
    }
}