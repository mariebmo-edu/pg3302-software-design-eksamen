using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    class StudentLecture
    {
        public long StudentId { get; set; }
        public long LectureId { get; set; }
        public Lecture Lecture { get; set; }
        public bool Seen { get; set; }
    }
}
