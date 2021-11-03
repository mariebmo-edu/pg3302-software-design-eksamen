using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Specialization Specialization { get; set; }
        public long SpecializationId { get; set; }
        public UserCoursePlan UserCoursePlan { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

    }
}