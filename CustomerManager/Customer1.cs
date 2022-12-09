using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerManager
{
    public partial class Customer1
    {
        public int? CId { get; set; }
        public string CName { get; set; }
        public string CSurname { get; set; }
        public string Ssn { get; set; }
        public string EMail { get; set; }
        public string GenderFk { get; set; }
        public int? AdressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public long? PostalCode { get; set; }
        public string StreetAdress { get; set; }
        public int? AdressCustomerFk { get; set; }
    }
}
