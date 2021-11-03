using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class Specialization
    {
        public long Id { get; set; }    
        public List<Semester> Semesters { get; set; } = new();
        public SpecializationCourses SpecializationCourses { get; set; }
        [NotMapped]
        public IProgression Progression { get; set; }
    }
}
