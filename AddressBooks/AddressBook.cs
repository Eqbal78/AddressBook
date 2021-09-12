using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBooks
{
    // Creating a Interface to hiding some code..
    public interface IContact
    {
         void ReadInputs();
        
         void AddContacts();
        
    }

    class AddressBook : IContact
    {
        public class Person
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string address { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
            public string phnNum { get; set; }
            public string email { get; set; }
        }
        //list holds variables in a specific order
        public static List<Person> list = new List<Person>();
        // Create a Dictionary to hold list value
        public static Dictionary<string, List<Person>> dictionary = new Dictionary<string, List<Person>>();


        //Add contacts into the list
        public void AddContacts()
        {
            while (true) 
            {
                Console.WriteLine("\nEnter an option:");
                Console.WriteLine("1.Add New Contact \n2.List of Contact \n3.Edit Contact \n4.Delete Contact \n5.Exit ");

                int choice = Convert.ToInt32(Console.ReadLine());
                // choose the options from user
                switch (choice)
                {
                    case 1:
                        ReadInputs();
                        Console.WriteLine();
                        break;
                    case 2:
                        ListPeople();
                        break;
                    case 3:
                        EditDetails();
                        break;
                    case 4:
                        DeleteContact();
                        break;
                    case 5:
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
            Console.WriteLine("Enter your Address Book Name: ");
            string bookName = Console.ReadLine();
            
            //Check unique Dictionary
            if (!dictionary.ContainsKey(bookName))
            {
                //Add contact in the Dictionary
                dictionary.Add(bookName, list);

                Console.WriteLine("Enter number of contacts you want to add :");
                int num = Convert.ToInt32(Console.ReadLine());

                // Multiple data enter at a time
                for (int i = 1; i <= num; i++)
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
                    person.zip = Console.ReadLine();


                    Console.WriteLine("Enter your Phone Number :");
                    person.phnNum = Console.ReadLine();

                    Console.WriteLine("Enter your Email Address :");
                    person.email = Console.ReadLine();

                    list.Add(person);
                }

            }
            else
            {
                Console.WriteLine("Address Book is already exists!");

            }
            ListPeople();

        }


        //view the contacts in a list
         public void ListPeople()
        {
            // Check list is Empty or not
            if (dictionary.Count == 0)
            {
                Console.WriteLine("Your address book is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nHere are the current people in your address book:\n");
            //Access the elements in the Dictionary
            foreach (KeyValuePair<string, List<Person>> Details in dictionary)
            {
                foreach (var value in Details.Value)
                {
                   
                    GetInfo(value);
                }
                break;
            }

        }
        // Create Method to Edit Contact Details.
        public void EditDetails()
        {
            // Enter First name From the User To Edit
            Console.WriteLine("Enter Person Name to edit details:");
            string name = Console.ReadLine();

            // Check all Value in List
            foreach (var value in list)
            {
                // Check Condition FirstName equal to Name
                if (value.firstName.Equals(name))
                {
                    
                    Console.WriteLine("Enter your new Address: ");
                    value.address = Console.ReadLine();

                    Console.WriteLine("Enter your new State: ");
                    value.state = Console.ReadLine();

                    Console.WriteLine("Enter your new ZipCode: ");
                    value.zip = Console.ReadLine();

                    Console.WriteLine("Enter your new Phone Number: ");
                    value.phnNum = Console.ReadLine();

                    Console.WriteLine("Enter your new Email Id: ");
                    value.email = Console.ReadLine();
                   
                    // Get the Value from GetInfo Method
                    GetInfo(value);
                    
                }
            }

        }

        // Create a Method to delete Contact
        public void DeleteContact()
        {
            // Enter First name From the User To Delete
            Console.WriteLine("Enter the Name to Delete Details");
            string name = Console.ReadLine();

            
            foreach (var value in list)
            {
                if (value.firstName.Equals(name))
                {
                    list.Remove(value);
                    ListPeople();
                    break;
                }
                
            }
        }

        // Display the values

        public void GetInfo(Person value)
        {
           
            Console.WriteLine("*******************************");
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
