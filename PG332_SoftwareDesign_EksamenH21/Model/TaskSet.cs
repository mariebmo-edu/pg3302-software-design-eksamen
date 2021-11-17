using PG332_SoftwareDesign_EksamenH21.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class TaskSet : IProgressable
    {
        public int Id { get; set; }
        public long LectureId { get; private set; }
        public List<Task> Tasks { get; set; }
        [NotMapped] public bool Published { get; set; } = true;
        [NotMapped] public string Title { get; } = "Oppgavesett";
    }
}