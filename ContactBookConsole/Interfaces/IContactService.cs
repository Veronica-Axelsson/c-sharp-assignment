using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookConsole.Interfaces
{
    internal interface IContactService
    {
        void ShowMenu();
        void AddContactToList();
        void GetAll();
        void Get();
        void RemoveContactFromList(IContact contact);
    }
}

