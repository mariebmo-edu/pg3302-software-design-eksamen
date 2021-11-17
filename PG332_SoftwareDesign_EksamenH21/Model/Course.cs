using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Course : IProgressable
    {
        public int Id { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        public SemesterEnum SemesterEnum { get; set; }
        public string CourseCode { get; set; }
        public List<Lecture> Lectures { get; set; }
        public DateTime ExamDate { get; set; }
        public ExamType ExamType { get; set; }
        public float CoursePoints { get; set; }
        [NotMapped] public bool Published { get; set; } = true;

        [NotMapped]
        public string Title => CourseCode;

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