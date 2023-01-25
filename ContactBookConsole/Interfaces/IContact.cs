namespace ContactBookConsole.Interfaces
{
    internal interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string StreetAddress { get; set; }
        string PostNumber { get; set; }
        string City { get; set; }
}
}