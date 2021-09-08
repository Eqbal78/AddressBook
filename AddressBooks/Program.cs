using System;

namespace AddressBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook obj = new AddressBook();
            obj.ReadInputs();
            obj.AddContacts();
           
            //obj.ListPeople();
        }
    }
}
