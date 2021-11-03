using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class CoursesInSpecialization
    {

        public SemesterEnum Semester { get; set; }
        public long Id { get; set; }
        public long SpecializationId { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
        public bool mandatory { get; set; }

    }
}
