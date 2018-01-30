using ContactManager.Domain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Domain.Entitites
{
    public class Person : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        
        public string PersonNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber), RegularExpression(@"^\+44\([0-9]{3}\)\s[0-9]{7}|\+44\([0-9]{4}\)\s[0-9]{6}|\+44\([0-9]{5}\)\s[0-9]{5}$")]
        public string Phone { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
