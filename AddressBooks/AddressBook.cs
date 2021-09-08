using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBooks
{
    // Creating a Interface to hiding some code..
    public interface IContact
    {
        public  void ReadInputs();
        public void AddContacts();
    }

    class AddressBook : IContact
    {
        public class Person
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string address { get; set; }
            public string state { get; set; }
            public int zip { get; set; }
            public int phnNum { get; set; }
            public string email { get; set; }
        }
        //list holds variables in a specific order
        public static List<Person> list = new List<Person>();

        //Add contacts into the list
        public void AddContacts()
        {
            while (true) 
            {
                Console.WriteLine("\nEnter an option:");
                Console.WriteLine("1.Add New Contact \n2.Exit");

                int choice = (Convert.ToInt32(Console.ReadLine()));

                AddressBook obj = new AddressBook();
                switch (choice)
                {
                    case 1:
                        obj.ReadInputs();
                        Console.WriteLine();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;

                    default:

                        Console.WriteLine("\nEnter Vaild Choice\n");
                        break;
                }
            }
           

        }


        //Get input from user
        public void ReadInputs()
        {

            Person person = new Person();
            Console.WriteLine("Enter your First Name :");
            person.firstName = Console.ReadLine();

            Console.WriteLine("Enter your Last Name :");
            person.lastName = Console.ReadLine();

            Console.WriteLine("Enter your Address :");
            person.address = Console.ReadLine();

            Console.WriteLine("Enter your State :");
            person.state = Console.ReadLine();

            Console.WriteLine("Enter your Zipcode :");
            person.zip = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your Phone Number :");
            person.phnNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your Email Address :");
            person.email = Console.ReadLine();

            list.Add(person);
            ListPeople();
            
        }


        //view the contacts in a list
        private static void ListPeople()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Your address book is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nHere are the current people in your address book:\n");
            //Access the elements in the list
            foreach (var value in list)
            {
                GetInfo(value);
            }

        }

        // Display the values

        static void GetInfo(Person value)
        {

            Console.WriteLine("Firstname you entered: " + value.firstName);
            Console.WriteLine("Lastname you entered: " + value.lastName);
            Console.WriteLine("Address you entered: " + value.address);
            Console.WriteLine("State you entered: " + value.state);
            Console.WriteLine("Zipcode you entered: " + value.zip);
            Console.WriteLine("Phone NUmber you entered: " + value.phnNum);
            Console.WriteLine("Email you entered: " + value.email);

        }
    }
}
