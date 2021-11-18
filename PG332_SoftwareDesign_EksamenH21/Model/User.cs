using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class User : IProgressable
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
#nullable enable
        public Address? Address { get; set; }
#nullable enable
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
#nullable enable
        public List<Semester> Semesters { get; set; } = new();
        [NotMapped] public SemesterEnum CurrentSemester { get; set; }
        [NotMapped] public bool Published { get; set; } = true;

        [NotMapped] public string Title => "Velg semester";

        public override bool Equals(object? obj)
        {
            if (obj is not User) return false;
            User user = (User) obj;
            return (user.Email == Email && user.UserId == UserId && user.FirstName == FirstName &&
                    user.LastName == LastName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}