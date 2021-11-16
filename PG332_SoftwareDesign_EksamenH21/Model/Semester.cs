using PG332_SoftwareDesign_EksamenH21.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Semester : IProgressable
    {
        public long Id { get; set; }
        public User User { get; set;  }
        public SemesterEnum SemesterEnum { get; set; }
        public List<Course> Courses { get; set; } = new();
        public bool Finished { get; set; } = false;
        [NotMapped] public bool Published { get; set; } = false;
    }
}