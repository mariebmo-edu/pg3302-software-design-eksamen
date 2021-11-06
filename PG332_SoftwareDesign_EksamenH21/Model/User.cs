using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public Specialization? Specialization { get; set; }
        public long? SpecializationId { get; set; }
        public long? UserCoursePlanId { get; set; }
        public StudentCourseOverview? StudentCourseOverview { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Address)}: {Address}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(Email)}: {Email}, {nameof(Specialization)}: {Specialization}, {nameof(SpecializationId)}: {SpecializationId}, {nameof(UserCoursePlanId)}: {UserCoursePlanId}, {nameof(StudentCourseOverview)}: {StudentCourseOverview}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not User) return false;
            User user = (User) obj;
            return (user.Email == Email && user.Id == Id && user.FirstName == FirstName && user.LastName == LastName);
        }

    }
}