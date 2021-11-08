using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class StudentCourseOverview
    {
        public long Id { get; set; }
        public Course Course { get; set; }
        public Status Status { get; set; }
        public Grade Grade { get; set; }
    }

    public enum Grade
    {
    }

    public enum Status
    {
    }
}
