namespace PG332_SoftwareDesign_EksamenH21
{
    public class User
    {
        public long id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}