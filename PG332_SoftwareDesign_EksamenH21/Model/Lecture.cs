using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Lecture : IFinishable
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Title { get; set; }
        public TaskSet TaskSet { get; set; }
        public DateTime LectureDateTime { get; set; }
        [NotMapped] public bool Published { get; set; } = false;

        [NotMapped] public bool Finished { get; set; } = false;
    }
}