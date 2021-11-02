using System;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Lecture
    {
        private TaskSet TaskSet { get; set; }
        private DateTime LectureDateTime { get; set; }
        private IProgression LectureProgression { get; set; }
        private IProgression TaskProgression { get; set; }
        private IProgression TotalProgression { get; set; }
    }
}