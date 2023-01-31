using ContactBookConsole.Services;


var menu = new ContactService
{
    FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json"
};

while (true)
{
	Console.Clear();
	menu.ShowMenu();
}
