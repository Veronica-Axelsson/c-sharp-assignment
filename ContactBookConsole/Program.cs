
bool value = true;

while (value == true)
{
    Console.WriteLine("\nVälkommen till Adressboken\r\n\r\n" +
        "1. Skapa en kontakt\r\n\r\n" +
        "2. Visa alla kontakter\r\n\r\n" +
        "3. Visa en specifik kontakt\r\n\r\n" +
        "4. Ta bort en specifik kontakt\r\n\r\n" +
        "5. Avsluta programmet.\r\n\r\n" +
        "Välj ett av alternativen ovan: ");

    int choice;
    Console.WriteLine("");
    choice = Convert.ToInt32(Console.ReadLine());


    if (choice == 1)
    {
        Console.WriteLine("\nDu valde 1");
    }

    else if (choice == 2)
    {
        Console.WriteLine("\nDu valde 2");
    }

    else if (choice == 3)
    {
        Console.WriteLine("\nDu valde 3");
    }

    else if (choice == 4)
    {
        Console.WriteLine("\nDu valde 4");
    }

    else if (choice == 5)
    {
        Console.WriteLine("\nDu valde 5. Programmet avslutas");
        value = false;
    }

    else
    {
        Console.WriteLine("Du valde något annat.");
    }
}








/*
 * 		public static void Main(string[] args)
		{
			string testString;
			Console.Write("Enter a string - ");
			testString = Console.ReadLine();
			Console.WriteLine("You entered '{0}'", testString);
		}
 
Huvudmenyn

När du startar programmet ska du komma till någon form av meny som skriver ut följande information på skärmen. 
Denna information ska komma upp första gången en användare startar programmet och sen efter att den har genomfört 
ett av alternativen. Så den ska alltså loopas på något sätt:



Välkommen till Adressboken

1. Skapa en kontakt

2. Visa alla kontakter

3. Visa en specifik kontakt

4. Ta bort en specifik kontakt

Välj ett av alternativen ovan: 



Skapa en kontakt

När användaren väljer detta alternativ så ska den få upp en tom skärm som det sedan ska listas upp information 
som man behöver knappa in. Det kan vara information såsom förnamn, efternamn, e-postadress, telefonnummer, 
gatuadress, postnummer och ort. När användaren har skrivit in all information så ska denna information sparas ner
i en lista. Denna lista ska sedan sparas ner till en json-fil så att informationen finns kvar även om du stänger 
av applikationen.



Visa alla kontakter

När användaren väljer detta alternativ så ska användaren få upp en tom skärm som sedan listar upp alla kontakter 
som är inlagda i listan. Varje kontakt ska skrivas ut på en egen rad och formateras på ett snyggt sätt. 
Endast förnamn, efternamn och e-postadress ska skrivas ut. Användaren måste sedan trycka på en valfri tangent 
för att komma tillbaka till huvudmenyn.



Visa en specifik kontakt

När användaren väljer detta alternativ så ska användaren få upp en tom skärm som sedan listar upp en specifik 
kontakt och dess information. Informationen ska skrivas ut så man ser följande format:

Förnamn: Hans
Efternamn: Mattin-Lassei
E-postadress: hans@domain.com
Telefonnummer: 073-123 45 67
Adress: Nordkapsvägen 1, 123 45 Stockholm

Användaren måste sedan trycka på en valfri tangent för att komma tillbaka till huvudmenyn.


Ta bort en specifik kontakt

När användaren väljer detta alternativ så ska användaren få upp en tom skärm som så ska användaren ange 
vilken kontaktperson man vill ta bort. Användaren ska sedan få frågan om hen är säker på att den vill ta 
bort kontakten. Om användaren skriver y så ska kontakten tas bort ifrån listan och även json-filen måste 
då uppdateras med rätt information. Därefter ska användaren komma tillbaka till huvudmenyn. Om användaren 
svarar n så ska användaren komma tillbaka till huvudmenyn utan att någon kontakt tas bor.
 
 
 
 
 */
