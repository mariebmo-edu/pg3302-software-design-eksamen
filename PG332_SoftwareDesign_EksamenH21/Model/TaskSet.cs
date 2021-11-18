using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class TaskSet : IProgressable
    {
        public int Id { get; set; }
        public Lecture Lecture { get; set; }
        public int LectureId { get; private set; }
        public List<Task> Tasks { get; set; }
        [NotMapped] public bool Published { get; set; } = true;
        [NotMapped] public string Title { get; } = "Oppgavesett";
    }
}