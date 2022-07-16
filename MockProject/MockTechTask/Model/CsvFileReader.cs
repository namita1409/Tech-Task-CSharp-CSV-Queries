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
        
        List<Person> personList = new List<Person>();
        int count = 0;

        public void FileReader()
        {
            const string fileName = @"D:\Learning\MockProject\input\input.csv";

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
            }
        }
        public void DisplayPersonLivingInCountyDerbyshire(string searchString)
        {        
            //finding number of people in a given county 
            var result = from person in personList
                         where person.County == searchString
                         select person;

            count = result.Count();
            Console.WriteLine("count " + count);
            foreach (var person in result)
            {
                int index = result.ToList().IndexOf(person);
                Console.WriteLine(index+person.FirstName + " " + person.County);
            }
        }
        public void DisplayPersonContainsCompanyEsq(string searchString)
        {
            //search every person who has Esq in their company name            
            var result = from person in personList
                         where person.Company.Contains(searchString)
                         select person;

            count = result.Count();
            Console.WriteLine(count);
            foreach (var person in result)
            {
                Console.WriteLine(person.FirstName + " " + person.Company);
            }
        }
        public void DisplayPersonWhoseHouseNoIsDigit()
        {
            //Every person whose house number is exactly three digits.
            var result = from person in personList
                         select person;
            
            List<Person> addressList = new List<Person>();
            foreach (var person in result)
            {                
                string address = person.Address;
                string sPattern = "^\\d{3}\\s";

                if (System.Text.RegularExpressions.Regex.IsMatch(address, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    count++;
                    addressList.Add(person);                                   
                }
            }
            Console.WriteLine(count);
            foreach (var person in addressList)
            {
                Console.WriteLine($"{person.FirstName} {person.Address}");
            }
        }
        public void DisplayPersonWhoseWebUrlIsLongThanThirtyFive()
        {
            //Every person whose website URL is longer than 35 characters
            var result = from person in personList
                         where person.web.Length > 35
                         select person;
            count = result.Count();
            Console.WriteLine(count);
            foreach (var person in result)
            {                
                Console.WriteLine(person.FirstName + " " + person.web);
            }
        }
        public void DisplayPersonWhoLivesInPostcode()
        {
            //Every person who lives in a postcode area with a single-digit value.
            var result = from person in personList
                         select person;
            
            List<Person> postalList = new List<Person>();
            foreach (var person in result)
            {                
                string postal = person.Postal;
                string sPattern = "^[A-Za-z]{2}\\d{1}\\s";

                if (System.Text.RegularExpressions.Regex.IsMatch(postal, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    count++;
                    postalList.Add(person);
                }
            }
            Console.WriteLine(count);
            foreach (var person in postalList) 
            {
                Console.WriteLine($"{ person.FirstName} {person.Postal}");
            }
        }
        public void DisplayPersonWhosePhoneNoIsLarger() 
        {
            var result = from person in personList
                     select person;
            
            List<Person> phone1List = new List<Person>();            
            foreach (var person in result)
            {
                string strPhone1 = person.Phone1;
                string strPhone2 = person.Phone2;
                long phone1 = phoneNumberConvert(strPhone1);
                long phone2 = phoneNumberConvert(strPhone2);
                if (phone1 > phone2)
                {
                    count++;
                    phone1List.Add(person);                   
                }               
            }
            Console.WriteLine(count);
            foreach (var p in personList)
            {
                Console.WriteLine($"{p.FirstName} {p.Company}");
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
         
                    
    

