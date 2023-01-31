using ContactBookConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookConsole.Models
{
    internal class Contact : IContact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get ; set ; } = null!;
        public string Email { get ; set ; } = null!;

        public string PhoneNumber { get ; set ; } = null!;

        public string StreetAddress { get ; set ; } = null!;

        public string PostNumber { get ; set ; } = null!;

        public string City { get ; set ; } = null!;
    }
}
