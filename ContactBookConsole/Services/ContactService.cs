using ContactBookConsole.Models;
using Newtonsoft.Json;

namespace ContactBookConsole.Services
{
    internal class ContactService
    {
        private List<Contact> contactsList = new();
        private readonly Contact contactPerson = new();             
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
                    contactsList = persons;
                }
            }
            catch { }

            //Menu
            Console.WriteLine("\nVälkommen till Adressboken\r\n\r\n" +
                    "1. Skapa en kontakt\r\n\r\n" +
                    "2. Visa alla kontakter\r\n\r\n" +
                    "3. Visa en specifik kontakt\r\n\r\n" +
                    "4. Ta bort en specifik kontakt\r\n\r\n" +
                    "5. Avsluta programmet.\r\n\r\n" +
                    "Välj ett av alternativen ovan: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddContactToList(); break;
                case "2": GetAll(); Console.Read(); break;
                case "3": Get(); break;
                case "4": RemoveContactFromList(); break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("\nDu valde 5. Programmet avslutas. Tryck på enter knapp för att fortsätta.");
                    System.Environment.Exit(0);
                    break;
                default:
                    ShowMenu();
                    break;
            }
            FileService.Save(FilePath, JsonConvert.SerializeObject(contactsList));
        }

        public void AddContactToList()
        {
            Console.Clear();
            Console.WriteLine("\nSkapa ny kontakt");

            Console.Write("\nFörnamn: ");
            contactPerson.FirstName = Console.ReadLine() ?? "";

            Console.Write("\nEfternamn: ");
            contactPerson.LastName = Console.ReadLine() ?? "";

            Console.Write("\nE-post: ");
            contactPerson.Email = Console.ReadLine() ?? "";

            Console.Write("\nTelefonnummer: ");
            contactPerson.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("\nGatuadress: ");
            contactPerson.StreetAddress = Console.ReadLine() ?? "";

            Console.Write("\nPostnummer: ");
            contactPerson.PostNumber = Console.ReadLine() ?? "";

            Console.Write("\nOrt: ");
            contactPerson.City = Console.ReadLine() ?? "";

            contactsList.Add(contactPerson);

            FileService.Save(FilePath, JsonConvert.SerializeObject(contactsList));
        }

        public void GetAll()
        {
            Console.Clear();
            Console.WriteLine("\nAlla kontakter: ");

            foreach (Contact x in contactsList)
            {
                Console.WriteLine($"Namn: {x.FirstName} {x.LastName}. E-mail: {x.Email}");
            }

            Console.WriteLine("\nTryck på enter tangent för att komma tillbaka till huvudmenyn");
            Console.Read();
        }

        public void Get()
        {
            Console.Clear();

            ////Visa en specifik kontakt. Skriv personens förnamn:
            Console.WriteLine($"\nSkriv personens förnamn: ");
            var searchFirstName = Console.ReadLine() ?? "";
            //var searchFirstName2 = searchFirstName.ToLower();

            //Letar efter kontakt, med hjälp av förnamn.
            var findContact = contactsList.Find(x => x.FirstName.ToLower() == searchFirstName.ToLower());
           
            if (findContact != null)
            {
                if ( findContact.FirstName.ToLower() == searchFirstName.ToLower())
                {
                    // Skriv personens Efternamn:
                    Console.WriteLine($"\nSkriv personens Efternamn: ");
                    var searchLastName = Console.ReadLine() ?? "";

                    //Letar efter kontakt, med hjälp av efternamn.
                    var findContact3 = contactsList.Find(x => x.LastName.ToLower() == searchFirstName.ToLower());
                    
                    if (findContact.LastName.ToLower() == searchLastName.ToLower())
                    {
                        Console.Clear();
                        //Visar kontaktinfo.
                        Console.WriteLine($"\nKontakt\r\n\r\n" +
                             $"Förnamn: {findContact.FirstName} \r\n\r\n" +
                             $"Efternamn: {findContact.LastName}\r\n\r\n" +
                             $"E-postadress: {findContact.Email}\r\n\r\n" +
                             $"Telefonnummer: {findContact.PhoneNumber}\r\n\r\n" +
                             $"Adress: {findContact.StreetAddress}, {findContact.PostNumber} {findContact.City}\r\n\r\n");

                        Console.WriteLine("Tryck på enter tangent för att komma tillbaka till menyn.");
                        Console.Read();
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("\nKunde inte hitta personens efternamn.");
                        Console.WriteLine("Tryck på enter tangent för att komma tillbaka till menyn.");
                        Console.Read();
                    }
                } else
                {
                    Console.Clear();
                    Console.WriteLine("\nKunde inte hitta personens förnamn.");
                    Console.WriteLine("Tryck på enter tangent för att komma tillbaka till menyn.");
                    Console.Read();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nKunde inte hitta kontakten.");
                Console.WriteLine("Tryck på enter tangent för att komma tillbaka till menyn.");
                Console.Read();
                ShowMenu();
            } 
        }

        public void RemoveContactFromList()
        {
            Console.Clear();

            //Ta bort en specifik kontakt. Skriv personens förnamn:
            Console.Write("\nTa bort en kontakt! ");
            Console.WriteLine($"\nSkriv personens förnamn: ");
            var searchFirstName = Console.ReadLine() ?? "";
            string searchFirstNameToLower = searchFirstName.ToLower();

            //Letar efter kontakt, med hjälp av förnamn.
            var findContact = contactsList.Find(x => x.FirstName.ToLower() == searchFirstName.ToLower());

            if (findContact != null)
            {
                if (findContact.FirstName.ToLower() == searchFirstName.ToLower())
                {
                    // Skriv personens efternamn:
                    Console.WriteLine($"\nSkriv personens Efternamn: ");
                    var searchLastName = Console.ReadLine() ?? "";

                    // Letar efter kontakt, med hjälp av efternamn.
                    var findContact3 = contactsList.Find(x => x.LastName.ToLower() == searchFirstName.ToLower());

                    if (findContact.LastName.ToLower() == searchLastName.ToLower())
                    {
                        Console.Clear();
                        // Visar kontaktinfo.
                        Console.WriteLine($"\nKontakt: {findContact.FirstName} {findContact.LastName}");
                        Console.WriteLine("\nVill du ta bort kontakten? Tryck y. För att avbryta tryck n");
                        var RemoveChoice = Console.ReadLine();

                        switch (RemoveChoice)
                        {
                            case "y":
                                // Ta bort kontakt
                                try
                                {
                                    contactsList.Remove(findContact);
                                    FileService.Save(FilePath, JsonConvert.SerializeObject(contactsList));
                                }
                                catch { }
                                Console.Clear();
                                Console.WriteLine("\nKontakten har tagits bort.");
                                Console.WriteLine("\nTryck på Enter tangent för att komma tillbaka till menyn.");
                                Console.Read();
                                ShowMenu();
                                break;

                            case "n":
                                Console.Clear();
                                // Avbryta att ta bort kontakt
                                Console.WriteLine("\nTa bort kontakt avbryts.");
                                Console.WriteLine("\nTryck på Enter tangent för att komma tillbaka till menyn.");
                                Console.Read();
                                Console.Clear();
                                ShowMenu();
                                break;

                            default:
                                Console.WriteLine("\nKontakten kunde inte hittas.");
                                Console.WriteLine("\nTryck på Enter tangent för att komma tillbaka till menyn.");
                                Console.Clear();
                                ShowMenu();
                                break;
                        }
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("\nPersonens efternamn kunde inte hittas.");
                        Console.WriteLine("\nTryck på Enter tangent för att komma tillbaka till menyn.");
                        Console.Read();
                        ShowMenu();
                    }
                } else
                {
                    Console.Clear();
                    Console.WriteLine("\nPersonens förnamn kunde inte hittas.");
                    Console.WriteLine("\nTryck på Enter tangent för att komma tillbaka till menyn.");
                    Console.Read();
                    ShowMenu();
                }

                    Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nKontaktens förnamn kunde inte hittas.");
                Console.WriteLine("\nTryck på Enter tangent för att komma tillbaka till menyn.");
                Console.Read();
                ShowMenu();
            }
        }
    }
}
