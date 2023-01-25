using ContactBookConsole.Interfaces;
using ContactBookConsole.Models;
using Newtonsoft.Json;
using ContactBookConsole.Services;
using System;
using System.Net;
using System.Xml.Linq;
using System.IO;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ContactBookConsole.Services
{
    internal class ContactService /*: IContactService*/
    {
        private List<Contact> contacts = new();
        private readonly FileService file = new();

        public string FilePath { get; set; } = null!;


        public void ShowMenu()
        {
            Console.Clear();
            //---------------------------------
            //Hämta lista.

            try
            {
                var persons = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
                if (persons != null)
                {
                    contacts = persons;
                }
            }
            catch { }

            //---------------------------------

            Console.WriteLine("\nVälkommen till Adressboken\r\n\r\n" +
                    "1. Skapa en kontakt\r\n\r\n" +
                    "2. Visa alla kontakter\r\n\r\n" +
                    "3. Visa en specifik kontakt\r\n\r\n" +
                    "4. Ta bort en specifik kontakt\r\n\r\n" +
                    "5. Avsluta programmet.\r\n\r\n" +
                    "Välj ett av alternativen ovan: ");


            Console.WriteLine("");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddContactToList(); break;
                case "2": GetAll(); Console.Read(); break;
                case "3": Get(); break;
                case "4": RemoveContactFromList(); break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("\nDu valde 5. Programmet avslutas. Tryck på valfri knapp för att fortsätta.");

                    System.Environment.Exit(0);
                    break;
                default:
                    ShowMenu();
                    
                
                    break;
            }
            file.Save(FilePath, JsonConvert.SerializeObject(contacts));
        }

            public void AddContactToList()
            {
                Console.Clear();
                Console.WriteLine("\nSkapa ny kontakt");

                Contact addContact = new();

                Console.Write("Förnamn: ");
                addContact.FirstName = Console.ReadLine() ?? "";

                Console.Write("Efternamn: ");
                addContact.LastName = Console.ReadLine() ?? "";

                Console.Write("E-post: ");
                addContact.Email = Console.ReadLine() ?? "";

                Console.Write("Telefonnummer: ");
                addContact.PhoneNumber = Console.ReadLine() ?? "";

                Console.Write("Gatuadress: ");
                addContact.StreetAddress = Console.ReadLine() ?? "";

                Console.Write("Postnummer: ");
                addContact.PostNumber = Console.ReadLine() ?? "";

                Console.Write("Stad: ");
                addContact.City = Console.ReadLine() ?? "";

                contacts.Add(addContact);

            file.Save(FilePath, JsonConvert.SerializeObject(contacts));   
        }

        public void GetAll()
            {
                Console.Clear();
                Console.WriteLine("\nAlla kontakter: ");

            foreach (Contact x in contacts)
            {
                Console.WriteLine($"Namn: {x.FirstName} {x.LastName}. E-mail: {x.Email}");
            }

            Console.WriteLine("\nTryck på en valfri tangent för att komma tillbaka till huvudmenyn");
                Console.Read();
                
            }


        public void Get()
            {
                //Visa en specifik kontakt
                //string inputFindName = "Tomte";
                Console.Clear();

                Console.Write("Skriv personens förnamn: ");
                string temp = Console.ReadLine() ?? "";

                int index = temp.IndexOf(temp);
                if (index != -1)
                {
                    Console.WriteLine(String.Format("\n1. Element {0} is found at index {1}", temp, index));
                    Console.WriteLine("2. " + index);

                    Console.WriteLine();

                    Console.WriteLine(contacts[index]);
                }
                else
                {
                    Console.WriteLine("Element not found in the given list."); 
                }

                Console.Read();
            }


        public static void RemoveContactFromList()
            {
                Console.Clear();
     

            //Ta bort en specifik kontakt

            ////Fråga efter namn
            //Console.Write("Skriv namnet på kontakten du vill få bort: ");
            //Contact tempName = Console.ReadLine() ?? "";

            ////Söker efter namn
            //int index = contacts.IndexOf(tempName);


            ////Resultat från sökning
            //if (index != -1)
            //{
            //    Console.WriteLine(String.Format("\n3. Name {0} kommer tas bort index {1}", tempName, index));
            //    contacts.RemoveAt(index);
            //}
            //else
            //{
            //    Console.WriteLine("Name not found in the given list.");
            //}

            Console.WriteLine("\nTryck på en valfri tangent för att komma tillbaka till huvudmenyn");
            Console.Read();

        }

    
    }
}
