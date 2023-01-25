
using ContactBookConsole.Interfaces;
using ContactBookConsole.Models;
using ContactBookConsole.Services;
using Newtonsoft.Json;
using System;


var menu = new ContactService
{
    FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json"
};

//var menu = new ContactService();

//menu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";


while (true)
{
	Console.Clear();
	menu.ShowMenu();
}



// ------ Attribute göra --------------------------------------

//Visa en specifik kontakt

//Ta bort en specifik kontakt




/* -----------------------------------------------------------------------------------------------------------------
 

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
