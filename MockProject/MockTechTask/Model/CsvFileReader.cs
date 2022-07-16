using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MockTechTask.Model;
using System.Text.RegularExpressions;


namespace MockTechTask.Model
{
    public class CsvFileReader
    {
        public void FileReader()
        {
            const string fileName = @"D:\Learning\MockProject\input\input.csv";
            List<Person> personList = new List<Person>();
            using (var stream = File.OpenRead(fileName))
            using (var reader = new StreamReader(stream))
            {
                var data = CsvParser.ParseHeadAndTail(reader, ',', '"');

                var header = data.Item1;
                var lines = data.Item2;

                foreach (var line in lines.Take(100))
                {
                    Person p = new Person();
                    int i = 0;
                    p.FirstName = line[0];
                    p.LastName = line[i + 1];
                    p.Company = line[i + 2];
                    p.Address = line[i + 3];
                    p.City = line[i + 4];
                    p.County = line[i + 5];
                    p.Postal = line[i + 6];
                    p.Phone1 = line[i + 7];
                    p.Phone2 = line[i + 8];
                    p.email = line[i + 9];
                    p.web = line[i + 10];
                    personList.Add(p);
                }


                string searchString = "Derbyshire";
                //finding number of people in a given city/county 
                var result = from person in personList
                             where person.County == searchString
                             select person;
                int count = result.Count();

                Console.WriteLine("count " + count);
                foreach (var person in result)
                {
                    Console.WriteLine(person.FirstName + " " + person.Company);
                }

                //search every person who has Esq in their company name
                searchString = "Esq";
                result = from person in personList
                         where person.Company.Contains(searchString)
                         select person;

                count = result.Count();
                Console.WriteLine(count);
                foreach (var person in result)
                {
                    Console.WriteLine(person.FirstName + " " + person.Company);
                }

                //Every person whose house number is exactly three digits.

                result = from person in personList
                         select person;
                //Console.WriteLine(count);
                count = 0;
                foreach (var person in result)
                {

                    //Console.WriteLine("Address: " + person.Address);
                    string address = person.Address;
                    string sPattern = "^\\d{3}\\s";

                    if (System.Text.RegularExpressions.Regex.IsMatch(address, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        count++;

                        //  Console.WriteLine(person.FirstName + " " + person.Company);

                        Console.WriteLine("Address: " + person.Address);
                        //  Console.WriteLine($"  (match for '{sPattern}' found)");

                    }


                }
                //Every person whose website URL is longer than 35 characters
                result = from person in personList
                         where person.web.Length > 35
                         select person;
                count = result.Count();
                Console.WriteLine(count);
                foreach (var person in result)
                {
                    //Console.WriteLine(person.FirstName + " " + person.Company);
                    Console.WriteLine(person.FirstName + " " + person.web);
                }


                //Every person who lives in a postcode area with a single-digit value.
                result = from person in personList
                         select person;

                count = 0;
                foreach (var person in result)
                {

                    //Console.WriteLine("Address: " + person.Address);
                    string postal = person.Postal;
                    string sPattern = "^[A-Za-z]{2}\\d{1}\\s";

                    if (System.Text.RegularExpressions.Regex.IsMatch(postal, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        count++;

                        //  Console.WriteLine(person.FirstName + " " + person.Company);

                        Console.WriteLine("Postal: " + person.Postal);
                        //  Console.WriteLine($"  (match for '{sPattern}' found)");

                    }
                }
                string phoneNumber = "01835-703597";
                //phone number test coversion from string to number test
                long lphoneNumber = phoneNumberConvert(phoneNumber);
                Console.WriteLine(lphoneNumber);

                result = from person in personList
                         select person;
                //Console.WriteLine(count);
                count = 0;
                foreach (var person in result)
                {
                    string strPhone1 = person.Phone1;
                    string strPhone2 = person.Phone2;
                    long phone1 = phoneNumberConvert(strPhone1);
                    long phone2 = phoneNumberConvert(strPhone2);
                    if (phone1 > phone2)
                    {
                        Console.WriteLine($"{person.FirstName}'s  Phone1({strPhone1}) is greater Phone2({strPhone2})");

                    }

                }
            }
        }

        private static long phoneNumberConvert(string phoneNumber)
        {
            // First, remove everything except of numbers
            Regex regexObj = new Regex(@"[^\d]");            
            //converting to long
            return Convert.ToInt64(regexObj.Replace(phoneNumber, ""));

        }

    }
}
         
                    
    

