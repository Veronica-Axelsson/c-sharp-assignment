using Microsoft.Azure.KeyVault.Models;

namespace ConsoleAppTest_xUnit
{
    public class Contact_Tests
    {
        private Contact contacts;
        Contact contactPerson;

        public Contact_Tests()
        {
            // arange
            contacts = new Contact();
            contactPerson = new Contact;
        }

        [Fact]
        public void Test1()
        {
            // act

            // assert

        }
    }
}