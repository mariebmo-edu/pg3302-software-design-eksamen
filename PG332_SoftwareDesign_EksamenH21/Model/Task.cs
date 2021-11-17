using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Task : IFinishable
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int TaskSetId { get; set; }
        public TaskSet TaskSet { get; set; }
        public string Description { get; set; }
        [NotMapped] public bool Published { get; set; } = true;
        public bool Finished { get; set; } 

        #region Overridden methods
            protected bool Equals(Task other)
            {
                return TaskSetId == other.TaskSetId && Title == other.Title && Description == other.Description &&
                       Published == other.Published && Finished == other.Finished;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Task) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Title, Description, Published, Finished);
            }

            public static bool operator ==(Task left, Task right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Task left, Task right)
            {
                return !Equals(left, right);
            }
        #endregion
    }
}