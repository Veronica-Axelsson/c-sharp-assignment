//Du ska göra ett enkelt enhetstest som kontrollerar om du har fått in en kontaktperson i listan med hjälp
//någon av följande xUnit/nUnit/MSTest (ett nytt projekt i samma solution).

using ContactBookConsole.Services;
using Contact = ContactBookConsole.Models.Contact;

namespace ConsoleAppTest_xUnit
{
    public class Contact_Tests
    {
        private readonly AddressBook addressBook;
        readonly Contact contact;

        public Contact_Tests()
        {
            // arange -------------------------------------
            addressBook = new();
            contact = new();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            // act ----------------------------------------
            addressBook.ContactList.Add(contact);
            addressBook.ContactList.Add(contact);


            // assert -------------------------------------
            Assert.Equal(2, addressBook.ContactList.Count);
        }
    }
}