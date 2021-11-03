using System;
using System.Collections.Generic;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Course
    {
        public long Id { get; set; }
        public List<Lecture> Lectures { get; set; }
        public DateTime ExamDate { get; set; }
        public ExamType ExamType { get; set; }
        public float CoursePoints { get; set; }
        public IProgression Progression { get; set; }
    }

    public enum ExamType
    {
        
    }
}