using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class CoursesInSpecialization
    {
        public long Id { get; set; }
        public long SpecializationId { get; set; }
        public List<Course> Courses { get; set; }
        public bool mandatory { get; set; }

    }
}
