using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Entity
{
    public class Phone
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }

        public Customer Customer { get; set; }
    }
}
