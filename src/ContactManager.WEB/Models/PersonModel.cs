using ContactManager.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.WEB.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime Birth { get; set; }
        
        public Gender Gender { get; set; }
        
        public string PersonNumber { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }

        public int AddressId { get; set; }

        public AddressModel Address { get; set; }
    }
}
