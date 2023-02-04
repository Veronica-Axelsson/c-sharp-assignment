//---------------------------------
//Class for testing.
//---------------------------------

using ContactBookConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookConsole.Services
{
    public class AddressBook
    {
        public List<Contact> ContactList { get; set; } = new List<Contact>();
    }
}
