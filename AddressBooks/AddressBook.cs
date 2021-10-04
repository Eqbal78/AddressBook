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
       
        /// <summary>
        /// list holds variables in a specific order
        /// </summary>
        public static List<Person> list = new List<Person>();

        /// <summary>
        /// Create a Dictionary to hold list value
        /// </summary>
        public static Dictionary<string, List<Person>> dictionary = new Dictionary<string, List<Person>>();


        /// <summary>
        /// Add contacts into the list
        /// </summary>
        public void AddContacts()
        {
            while (true) 
            {
                Console.WriteLine("\nEnter an option:");
                Console.WriteLine("1.Add New Contact \n2.List of Contact \n3.Edit Contact \n4.Delete Contact \n5.Search Contact by City or State \n6.View Contact by City or State \n7.Number of Contacts Count by City or State \n8.Exit ");

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
                        SearchDetails();
                        break;
                    case 6:
                        ViewDetailsByStateOrCity();
                        break;
                    case 7:
                        CountByStateOrCity();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                   

                    default:

                        Console.WriteLine("\nEnter Vaild Choice\n");
                        break;
                }
            }
           
        }



        /// <summary>
        /// Get input from user
        /// </summary>
        public void ReadInputs()
        {
            Console.WriteLine("\nEnter your Address Book Name: ");
            string bookName = Console.ReadLine();
            Console.WriteLine("\n-----------------------------------\n");
            
            //Check unique Dictionary
            if (!dictionary.ContainsKey(bookName))
            {
                //Add contact in the Dictionary
                dictionary.Add(bookName, list);

                Console.WriteLine("Enter number of contacts you want to add :");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n----------------------------------\n");

                // Multiple data enter at a time
                for (int i = 1; i <= num; i++)
                {
                    Person person = new Person();

                    while (true)
                    {
                        //Check Duplicate Entry
                        Console.WriteLine("Check Duplicate Entry");
                        Console.Write("\nEnter First Name: ");
                        string firstName = Console.ReadLine();
                        if (list.Count > 0)
                        {
                            //Using lambda expression
                            var x = list.Find(x => x.firstName.Equals(firstName));
                            if (x != null)
                            {
                                Console.WriteLine("Your name  already exists\n");
                                Console.WriteLine("**************************");
                            }
                            else
                            {
                                person.firstName = firstName;
                                Console.WriteLine("There is no such name. You can add this name!!");
                                Console.WriteLine("\n-------------------------");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no such name. You can add this name!!");
                            Console.WriteLine("\n-------------------------");
                            person.firstName = firstName;
                            break;
                        }

                    }

                    //Add Contacts
                    Console.WriteLine("\nEnter your First Name :");
                    person.firstName = Console.ReadLine();

                    Console.WriteLine("\nEnter your Last Name :");
                    person.lastName = Console.ReadLine();

                    Console.WriteLine("\nEnter your Address :");
                    person.address = Console.ReadLine();

                    Console.WriteLine("\nEnter your City :");
                    person.city = Console.ReadLine();

                    Console.WriteLine("\nEnter your State :");
                    person.state = Console.ReadLine();

                    Console.WriteLine("\nEnter your Zipcode :");
                    person.zip = Console.ReadLine();


                    Console.WriteLine("\nEnter your Phone Number :");
                    person.phnNum = Console.ReadLine();

                    Console.WriteLine("\nEnter your Email Address :");
                    person.email = Console.ReadLine();
                    Console.WriteLine("***********************************\n");

                    list.Add(person);
                }

            }
            else
            {
                Console.WriteLine("\nAddress Book is already exists!");

            }
            ListPeople();

        }


        /// <summary>
        /// view the contacts in a list
        /// </summary>
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

        /// <summary>
        /// Create Method to Edit Contact Details.
        /// </summary>
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

                    Console.WriteLine("\nEnter your new City: ");
                    value.city = Console.ReadLine();

                    Console.WriteLine("\nEnter your new State: ");
                    value.state = Console.ReadLine();

                    Console.WriteLine("\nEnter your new ZipCode: ");
                    value.zip = Console.ReadLine();

                    Console.WriteLine("\nEnter your new Phone Number: ");
                    value.phnNum = Console.ReadLine();

                    Console.WriteLine("\nEnter your new Email Id: ");
                    value.email = Console.ReadLine();
                    Console.WriteLine("\n***************************************\n");
                   
                    // Get the Value from GetInfo Method
                    GetInfo(value);
                    
                }
            }

        }

        //Create a Method to delete Contact 
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

        /// <summary>
        ///  Display the values
        /// </summary>
        /// <param name="value"></param>

        public void GetInfo(Person value)
        {
           
            Console.WriteLine("\n*******************************\n");
            Console.WriteLine("Firstname you entered: " + value.firstName);
            Console.WriteLine("Lastname you entered: " + value.lastName);
            Console.WriteLine("Address you entered: " + value.address);
            Console.WriteLine("City you entered: " + value.city);
            Console.WriteLine("State you entered: " + value.state);
            Console.WriteLine("Zipcode you entered: " + value.zip);
            Console.WriteLine("Phone NUmber you entered: " + value.phnNum);
            Console.WriteLine("Email you entered: " + value.email);            

        }

        /// <summary>
        /// Search Contact city or state
        /// </summary>
        public void SearchDetails()
        {
            string personName;
            Console.WriteLine("1.Search by city name\n2.Search By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("\nEnter the name of city in which you want to search:");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("\nEnter the name of person you want to search:");
                    personName = Console.ReadLine();
                    Console.WriteLine("\n-----------------------------------------");
                    SearchByCityName(cityName, personName);
                    break;
                case 2:
                    Console.WriteLine("\nEnter the state of city in which you want to search:");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("\nEnter the name of person you want to search:");
                    personName = Console.ReadLine();
                    Console.WriteLine("\n----------------------------------------\n");
                    SearchByStateName(stateName, personName);
                    break;
                default:
                    return;

            }

        }

        /// <summary>
        /// Search By City Name in Address Book
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="personName"></param>
        public void SearchByCityName(string cityName, string personName)
        {
            //check Dictionary is empty or not
            if (dictionary.Count > 0)
            {
                //Treverse
                foreach (KeyValuePair<string, List<Person>> dict in dictionary)
                {
                    //Find Contacts using lambda expression
                    list = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.city.Equals(cityName));


                }
                //check list is empty or not
                if (list.Count > 0)
                {
                    foreach (var x in list)
                    {
                        GetInfo(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }

        /// <summary>
        /// Search by State Name in Address Book
        /// </summary>
        /// <param name="stateName"></param>
        /// <param name="personName"></param>
        public void SearchByStateName(string stateName, string personName)
        {
            //check Dictionary is empty or not
            if (dictionary.Count > 0)
            {
                //Treverse
                foreach (KeyValuePair<string, List<Person>> dict in dictionary)
                {
                    //Find Contacts using lambda expression
                    list = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(stateName));

                }
                //check list is empty or not
                if (list.Count > 0)
                {
                    foreach (var x in list)
                    {
                        GetInfo(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }

        /// <summary>
        /// View Detail by City or State
        /// </summary>
        public void ViewDetailsByStateOrCity()
        {

            Console.WriteLine("\n1.View by city name\n2.View By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("\nEnter the name of city in which you want to view:");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("\n-----------------------------------------");
                    ViewByCityName(cityName, "view");
                    break;
                case 2:
                    Console.WriteLine("\nEnter the name of state in which you want to view:");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("\n---------------------------------------------");
                    ViewByStateName(stateName, "view");
                    break;
                default:
                    return;

            }

        }

        public void CountByStateOrCity()
        {

            Console.WriteLine("\n1.Number of contacts by city name \n2.Number of contacts by state name \nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("\nEnter the name of city in which you want to count persons:");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("\n-----------------------------------------");
                    ViewByCityName(cityName, "count");
                    break;
                case 2:
                    Console.WriteLine("\nEnter the name of state in which you want to count persons:");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("\n-----------------------------------------");
                    ViewByStateName(stateName, "count");
                    break;
                default:
                    return;

            }

        }

        /// <summary>
        /// View Detail by City name
        /// </summary>
        /// <param name="cityName"></param>
        public void ViewByCityName(string cityName, string check)
        {
            if (dictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Person>> dict in dictionary)
                {
                    list = dict.Value.FindAll(x => x.city.Equals(cityName));
                }
                if (check.Equals("view"))
                {
                    if (list.Count > 0)
                    {
                        foreach (var x in list)
                        {
                            GetInfo(x);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo Persons found");
                    }
                }
                else
                {
                    int countCity = list.Count;
                    Console.WriteLine($"\nThe total persons in {cityName} are : {countCity}");
                }

            }
            else
            {
                Console.WriteLine("\nAdress book is empty");
            }
        }

        /// <summary>
        /// View Datail By state name
        /// </summary>
        /// <param name="stateName"></param>
        public void ViewByStateName(string stateName, string check)
        {
            if (dictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Person>> dict in dictionary)
                {
                    list = dict.Value.FindAll(x => x.state.Equals(stateName));
                }

                if (check.Equals("view"))
                {
                    if (list.Count > 0)
                    {
                        foreach (var x in list)
                        {
                            GetInfo(x);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo Persons found");
                    }
                }
                else
                {
                    int countState = list.Count;
                    Console.WriteLine($"\nThe total persons in {stateName} are : {countState}");
                }
            }

            else
            {
                Console.WriteLine("\nAdress book is empty");
            }
        }
    }
}
