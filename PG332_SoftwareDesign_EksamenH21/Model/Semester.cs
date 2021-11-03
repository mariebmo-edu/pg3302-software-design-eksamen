using System.Collections.Generic;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Semester
    {
        public long Id { get; set; }
        public List<Course> Courses { get; set; }
        public IProgression Progression { get; set; }
        private List<Course> _optionalCourses = new();
        
        public void AddOptionalCourse(Course course) {
            _optionalCourses.Add(course);
        }

        public List<Course> GetOptionalCourses()
        {
            return _optionalCourses;
        }
    }
}