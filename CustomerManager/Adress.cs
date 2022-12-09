using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerManager
{
    public partial class Adress
    {
        public int AdressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public long PostalCode { get; set; }
        public string StreetAdress { get; set; }
        public int AdressCustomerFk { get; set; }

        public virtual Customer AdressCustomerFkNavigation { get; set; }
    }
}
