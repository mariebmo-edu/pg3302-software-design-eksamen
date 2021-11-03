using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class SpecializationCourses
    {
        public long Id { get; set; }
        public long SpecializationId { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
        public bool mandatory { get; set; }

    }
}
