using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerManager
{
    public partial class Customer
    {
        public Customer()
        {
            Adresses = new HashSet<Adress>();
            Phones = new HashSet<Phone>();
        }

        public int CId { get; set; }
        public string CName { get; set; }
        public string CSurname { get; set; }
        public string Ssn { get; set; }
        public string EMail { get; set; }
        public string GenderFk { get; set; }

        public virtual ICollection<Adress> Adresses { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
