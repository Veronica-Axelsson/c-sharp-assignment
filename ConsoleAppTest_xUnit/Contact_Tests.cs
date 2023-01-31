//Du ska göra ett enkelt enhetstest som kontrollerar om du har fått in en kontaktperson i listan med hjälp någon av
//följande xUnit/nUnit/MSTest (ett nytt projekt i samma solution).

using ContactBookConsole.Services;
using Contact = ContactBookConsole.Models.Contact;

namespace ConsoleAppTest_xUnit
{
    public class Contact_Tests
    {
        //private  Contact contacs;
        //Contact contactPerson;

        //private AddressBook addressBook;
        //Contact contactPerson2;

        private readonly Contact contactsList = new();
        readonly Contact contactPerson = new();

        public Contact_Tests()
        {
            // arange -------------------------------------
            //addressBook = new AddressBook();
            //contactPerson2 = new Contact();

            contactsList = new Contact();
            contactPerson = new Contact();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            // act ----------------------------------------
            contactsList.AddContactToList.Add(contactPerson);
            contactsList.AddContactToList.Add(contactPerson);

        

            // assert -------------------------------------
            Assert.Equal(2, contactsList.ContactList.Count);
        }
    }
}