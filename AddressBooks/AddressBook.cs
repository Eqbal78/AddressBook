using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBooks
{
    // Creating a Interface to hiding some code..
    public interface IContact
    {
        public  void ReadInputs();
    }

    class AddressBook : IContact
    {
        // Initialize all variable
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public int phnNum { get; set; }
        public string email { get; set; }
        
        // Create a Empty List
        public static List<AddressBook> list = new List<AddressBook>();

        public  void ReadInputs()
        {
            // Input from the User
            Console.WriteLine("Enter your First Name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter your Last Name :");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter your Address :");
            string address = Console.ReadLine();

            Console.WriteLine("Enter your State :");
            string state = Console.ReadLine();

            Console.WriteLine("Enter your Zipcode :");
            int zip = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your Phone Number :");
            int phnNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your Email Address :");
            string email = Console.ReadLine();


            Console.WriteLine("Firstname you entered: " + firstName);
            Console.WriteLine("Lastname you entered: " + lastName);
            Console.WriteLine("Address you entered: " + address);
            Console.WriteLine("State you entered: " + state);

            Console.WriteLine("Zipcode you entered: " + zip);
            Console.WriteLine("Phone NUmber you entered: " + phnNum);
            Console.WriteLine("Email you entered: " + email);
            
        }
    }
}
