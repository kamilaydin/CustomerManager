namespace CustomerAPI.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }

        public Customer Customer { get; set; }
    }
}
