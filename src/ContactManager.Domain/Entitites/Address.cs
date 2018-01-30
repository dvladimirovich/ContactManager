using ContactManager.Domain.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Domain.Entitites
{
    public class Address : IEntity
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        [DataType(DataType.PostalCode)]
        public string Postal { get; set; }

        public List<Person> People { get; set; }

        public Address()
        {
            People = new List<Person>();
        }
    }
}
