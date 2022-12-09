using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Entity
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string SocialSecurityNumber { get; set; }
        public char Gender { get; set; }
        [NotMapped]
        public bool UnUsualName { get; set; }

        public ICollection<Phone> Phones { get; set; }
        public ICollection<Address> Addresses { get; set; }
        
    }
}
