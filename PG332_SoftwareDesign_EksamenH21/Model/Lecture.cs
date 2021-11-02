using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Lecture
    {
        public long Id { get; set; }
        private TaskSet TaskSet { get; set; }
        private DateTime LectureDateTime { get; set; }
        [NotMapped]
        private IProgression LectureProgression { get; set; }
        [NotMapped]
        private IProgression TaskProgression { get; set; }
        [NotMapped]
        private IProgression TotalProgression { get; set; }
    }
}