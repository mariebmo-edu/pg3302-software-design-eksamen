using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Semester
    {
        public long Id { get; set; }
        public List<Course> Courses { get; set; } = new();
        [NotMapped]
        public IProgression Progression { get; set; }

        private List<Course> OptionalCourses { get; set; } = new();
    }
}