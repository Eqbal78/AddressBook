using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace AddressBooks
{
    public class File_IO
    {
        static String FilePath = @"C:\Users\HP\Desktop\practice_dotnet\AddressBooks\AddressBook\AddressBooks\Details.txt";
        static String CsvPath = @"C:\Users\HP\Desktop\practice_dotnet\AddressBooks\AddressBook\AddressBooks\ContactData.csv";

        /// <summary>
        /// Write the Text from File
        /// </summary>
        /// <param name="persons">create list passing person details</param>
        public static void WriteTxtFile(List<Person> persons)
        {
            if (File.Exists(FilePath))
            {
                //append the contacts in the file 
                using (StreamWriter streamWriter = File.AppendText(FilePath))
                {
                    foreach (Person person in persons)
                    {
                        streamWriter.WriteLine("\nFirstName: " + person.firstName);
                        streamWriter.WriteLine("LastName: " + person.lastName);
                        streamWriter.WriteLine("Address: " + person.address);
                        streamWriter.WriteLine("City    : " + person.city);
                        streamWriter.WriteLine("State   : " + person.state);
                        streamWriter.WriteLine("ZipCode: " + person.zip);
                        streamWriter.WriteLine("PhoneNum: " + person.phnNum);
                        streamWriter.WriteLine("Email   : " + person.email);
                        
                        

                    }
                    streamWriter.Close();
                }
                Console.WriteLine("\nWritting Persons detail in to the Text file");
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }

        /// <summary>
        /// Read the contacts in the file
        /// </summary>
        public static void ReadTxtFile()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader streamReader = File.OpenText(FilePath))
                {
                    String personDetails = "";
                    while ((personDetails = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine((personDetails));
                    }
                }
                
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }
        /// <summary>
        /// Write the file using csv helper
        /// </summary>
        /// <param name="person"></param>
        public static void WriteContactsIntoCsv(List<Person> person)
        {

            //open the stream file in write mode
            using (StreamWriter stream = new StreamWriter(CsvPath))
            // open csv file in write mode
            using (CsvWriter csvWriter = new CsvWriter(stream, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecord(person);
            }
            Console.WriteLine("\nData line added to CSV file...");
            ReadContactsFromCSV();
        }

        /// <summary>
        /// read the file using csv helper
        /// </summary>
        public static void ReadContactsFromCSV()
        {
            //open the stream file in write mode       
            using (StreamReader reader = new StreamReader(CsvPath))
            using (var read = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var contacts = read.GetRecords<Person>().ToList();
                foreach (Person contact in contacts)
                {
                    Console.WriteLine(contact.firstName + "," + contact.lastName + "," + contact.address + "," + contact.city + "," + contact.state + "," + contact.zip + "," + contact.phnNum + "," + contact.email);
                }
            }

        }
    }
}
