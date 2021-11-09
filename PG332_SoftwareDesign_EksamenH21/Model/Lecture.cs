using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Lecture : IFinishable
    {
        public string Title { get; set; }
        public long Id { get; set; }
        public TaskSet TaskSet { get; set; } = new();
        public DateTime LectureDateTime { get; set; }
        [NotMapped] public bool Published { get; set; } = false;

        [NotMapped] public bool Finished { get; set; } = false;
    }
}