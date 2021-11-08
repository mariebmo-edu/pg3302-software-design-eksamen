namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class Address
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}