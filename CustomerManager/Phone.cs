using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerManager
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneCustomerFk { get; set; }

        public virtual Customer PhoneCustomerFkNavigation { get; set; }
    }
}
