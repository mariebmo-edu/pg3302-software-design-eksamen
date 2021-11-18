using System;
using System.ComponentModel.DataAnnotations.Schema;
using PG332_SoftwareDesign_EksamenH21.Model;

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
        public bool Published { get; set; } = true;

        public bool Finished { get; set; }
    }
}