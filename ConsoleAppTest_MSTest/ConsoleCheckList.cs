//Du ska g�ra ett enkelt enhetstest som kontrollerar om du har f�tt in en kontaktperson i listan med hj�lp n�gon av
//f�ljande xUnit/nUnit/MSTest (ett nytt projekt i samma solution).

//using ContactBookConsole.Models;

using ContactBookConsole.Models;
using ContactBookConsole.Services;

namespace ConsoleAppTest_MSTest
{
    [TestClass]
    public class ConsoleCheckList
    {
        [TestMethod]
        public void Should_Add_Contact_To_List()
        {
            // Arrange
            AddressBook addressBook= new();
            Contact contact= new();

            // Act
            addressBook.ContactList.Add(contact);


            // Assert
            Assert.AreEqual(1, addressBook.ContactList.Count);
        }
    }
}