using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class Semester : IPublishable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set;  }
        public SemesterEnum SemesterEnum { get; set; }
        public List<Course> Courses { get; set; }
        public bool Finished { get; set; } = false; 
        public bool Published { get; set; } = true;

        [NotMapped]
        public string Title => SemesterEnum.ToString();
    }
}

