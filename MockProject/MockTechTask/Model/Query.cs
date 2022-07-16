using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MockTechTask.Model
{
    public class Query
    {
        int count = 0;

        public void DisplayPersonContainsCompanyEsq(List<Person> personList)
        {
            string searchString = "Esq";

            //search every person who has Esq in their company name            
            var result = from person in personList
                         where person.Company.Contains(searchString)
                         select person;

            count = result.Count();
            Console.WriteLine(count);
            foreach (var person in result)
            {
                int index = result.ToList().IndexOf(person);
                Console.WriteLine(index + " " + person.FirstName + " " + person.Company);
            }
        }
        public int DisplayPersonLivingInCountyDerbyshire(List<Person> personList)
        {
            string searchString = "Derbyshire";

            //finding number of people in a given county 
            var result = from person in personList
                         where person.County == searchString
                         select person;

            count = result.Count();
            Console.WriteLine("count " + count);
            foreach (var person in result)
            {
                int index = result.ToList().IndexOf(person);
                Console.WriteLine(index + " " + person.FirstName + " " + person.County);
            }
            return count;
        }
        public void DisplayPersonWhoseHouseNoIsDigit(List<Person> personList)
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

                int index = addressList.IndexOf(person);
                Console.WriteLine($"{ index } {person.FirstName} {person.Address}");
            }
        }
        public void DisplayPersonWhoseWebUrlIsLongThanThirtyFive(List<Person> personList)
        {
            //Every person whose website URL is longer than 35 characters
            var result = from person in personList
                         where person.web.Length > 35
                         select person;
            count = result.Count();
            Console.WriteLine(count);
            foreach (var person in result)
            {
                int index = result.ToList().IndexOf(person);
                Console.WriteLine(index+" " + person.FirstName + " " + person.web);
            }
        }
        public void DisplayPersonWhoLivesInPostcode(List<Person> personList)
        {
            //Every person who lives in a postcode area with a single-digit value.
            var result = from person in personList
                         select person;

            List<Person> postalList = new List<Person>();
            foreach (var person in result)
            {
                string postal = person.Postal;
                string sPattern = "^[A-Za-z]{2}\\d{1}\\s";

                if (Regex.IsMatch(postal, sPattern,RegexOptions.IgnoreCase))
                {
                    count++;
                    postalList.Add(person);
                }
            }
            Console.WriteLine(count);
            foreach (var person in postalList)
            {
                int index = postalList.IndexOf(person);
                Console.WriteLine($"{ index } { person.FirstName} {person.Postal}");
            }
        }
        public void DisplayPersonWhosePhoneNoIsLarger(List<Person> personList)
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
            foreach (var p in phone1List)
            {
                int index = phone1List.IndexOf(p);
                Console.WriteLine($"{ index } {p.FirstName} {p.Phone1}");
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