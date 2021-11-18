using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class Course : IFinishable
    {
        public int Id { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        public SemesterEnum SemesterEnum { get; set; }
        public string CourseCode { get; set; }
        public List<Lecture> Lectures { get; set; } = new();
        public DateTime ExamDate { get; set; }
        public ExamType ExamType { get; set; }
        public float CoursePoints { get; set; }
        [NotMapped] public bool Published { get; set; } = true;
        public bool Finished { get; set; }

        [NotMapped] public string Title => CourseCode;

        public override string ToString()
        {
            return $"{CourseCode} | {CoursePoints}";
        }
    }

    public enum ExamType
    {
        WRITTEN,
        HOME_24_HR,
        HOME_48_HR,
        PROJECT,
        ORAL,
    }
}