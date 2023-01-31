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
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;

namespace ContactBookConsole.Services
{
    internal class ContactService
    {
        private List<Contact> contacts = new();
        private readonly Contact contactPerson = new();  
             
        //private readonly FileService file = new();

        public string FilePath { get; set; } = null!;


        public void ShowMenu()
        {
            Console.Clear();
            //---------------------------------
            //Read from file
            try
            {
                var persons = JsonConvert.DeserializeObject<List<Contact>>(FileService.Read(FilePath));
                if (persons != null)
                {
                    contacts = persons;
                }
            }
            catch { }
            //---------------------------------

            //Menu
            Console.WriteLine("\nVälkommen till Adressboken\r\n\r\n" +
                    "1. Skapa en kontakt\r\n\r\n" +
                    "2. Visa alla kontakter\r\n\r\n" +
                    "3. Visa en specifik kontakt\r\n\r\n" +
                    "4. Ta bort en specifik kontakt\r\n\r\n" +
                    "5. Avsluta programmet.\r\n\r\n" +
                    "Välj ett av alternativen ovan: ");

            //Console.WriteLine("");
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
            FileService.Save(FilePath, JsonConvert.SerializeObject(contacts));
        }

        public void AddContactToList()
        {
            Console.Clear();
            Console.WriteLine("\nSkapa ny kontakt");

            Console.Write("Förnamn: ");
            contactPerson.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            contactPerson.LastName = Console.ReadLine() ?? "";

            Console.Write("E-post: ");
            contactPerson.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            contactPerson.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Gatuadress: ");
            contactPerson.StreetAddress = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            contactPerson.PostNumber = Console.ReadLine() ?? "";

            Console.Write("Stad: ");
            contactPerson.City = Console.ReadLine() ?? "";

            contacts.Add(contactPerson);

            FileService.Save(FilePath, JsonConvert.SerializeObject(contacts));
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
            Console.Clear();

            ////Visa en specifik kontakt. Skriv personens förnamn:
            Console.WriteLine($"Skriv personens förnamn: ");
            var searchFirstName = Console.ReadLine() ?? "";
            //searchFirstName = searchFirstName.ToLower();

            //Letar efter kontakt, med hjälp av förnamn.
            var findContact = contacts.Find(x => x.FirstName.Contains(searchFirstName));

            if (findContact != null)
            {
                Console.Clear();

                //Visar kontaktinfo.
                Console.WriteLine($"Kontakt\r\n\r\n" +
                     $"Förnamn: {findContact.FirstName} \r\n\r\n" +
                     $"Efternamn: {findContact.LastName}\r\n\r\n" +
                     $"E-postadress: {findContact.Email}\r\n\r\n" +
                     $"Telefonnummer: {findContact.PhoneNumber}\r\n\r\n" +
                     $"Adress: {findContact.StreetAddress}, {findContact.PostNumber} {findContact.City}\r\n\r\n");

                Console.WriteLine("tryck på valfri tangent för att komma tillbaka till menyn.");
                Console.Read();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Kunde inte hitta kontakten.");
                Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till menyn.");
                Console.Read();
                ShowMenu();
            }
         
        }

        public void RemoveContactFromList()
        {
            Console.Clear();

            //Ta bort en specifik kontakt. Skriv personens förnamn:
            Console.Write("Ta bort en kontakt! ");
            Console.WriteLine($"Skriv personens förnamn: ");
            var searchFirstName = Console.ReadLine() ?? "";

            //Letar efter kontakt, med hjälp av förnamn.
            var findContact = contacts.Find(x => x.FirstName.Contains(searchFirstName));

            if (findContact != null)
            {
                Console.Clear();

                //Visar kontaktinfo.
                Console.WriteLine($"Kontak: {findContact.FirstName} {findContact.LastName}");
                Console.WriteLine("Vill du ta bort kontakten? Tryck y. För att avbryta tryck n");
                var RemoveChoice = Console.ReadLine();

                switch (RemoveChoice)
                {
                    case "y":
                        // Ta bort kontakt
                        try
                        {
                            contacts.Remove(findContact);
                            FileService.Save(FilePath, JsonConvert.SerializeObject(contacts));
                        }
                        catch { }

                        Console.WriteLine("Kontakten har tagits bort.");
                        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till menyn.");
                        Console.Read();
                        ShowMenu();
                        break;

                    case "n":
                        // Avbryta att ta bort kontakt
                        Console.WriteLine("Ta bort kontakt avbryts.");
                        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till menyn.");
                        Console.Read();
                        Console.Clear();
                        ShowMenu();
                        break;
 
                    default:
                        
                   
                        Console.WriteLine("Kontakten kunde inte hittas.");
                        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till menyn.");

             
                        //Console.Clear() ;
                        //ShowMenu();
                        break;
                }
            }
        }
    }
}
