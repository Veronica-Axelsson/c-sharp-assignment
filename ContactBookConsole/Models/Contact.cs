using ContactBookConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookConsole.Models
{
    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get ; set ; } = null!;

        public string Email { get ; set ; } = null!;

        public string PhoneNumber { get ; set ; } = null!;

        public string StreetAddress { get ; set ; } = null!;

        public string PostNumber { get ; set ; } = null!;

        public string City { get ; set ; } = null!;

        public List<Contact> ContactList { get; set; } = null!;

        public Contact AddContactToList { get; set; } = null!;

        public void Add(Contact contactPerson)
        {
            throw new NotImplementedException();
        }
    }
}
