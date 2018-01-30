using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.WEB.Models
{
    public class AddressModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
        
        public string Postal { get; set; }

        public List<PersonModel> People { get; set; }

        public AddressModel()
        {
            People = new List<PersonModel>();
        }
    }
}
