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
        public string Name { get; set; }
        public string? Code { get; set; }
        public List<CoursesInSpecialization>? CoursesInSpecializations { get; set; }
        [NotMapped]
        public IProgression Progression { get; set; }
    }
}
