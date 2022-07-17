using MockTechTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MockTechTask.Query
{
    public class Query
    {
        int count = 0;

        public List<Person> DisplayPersonContainsCompanyEsq(List<Person> personList)
        {
            string searchString = "Esq";

            //search every person who has Esq in their company name            
            var result = from person in personList
                         where person.Company.Contains(searchString)
                         select person;          
                    
            return result.ToList();
        }
        public List<Person> DisplayPersonLivingInCountyDerbyshire(List<Person> personList)
        {
            string searchString = "Derbyshire";

            //finding number of people in a given county 
            var result = from person in personList
                         where person.County == searchString
                         select person;           
                        
            return result.ToList();
        }
        public List<Person> DisplayPersonWhoseHouseNoIsDigit(List<Person> personList)
        {
            //Every person whose house number is exactly three digits.
            var result = from person in personList
                         select person;

            List<Person> addressList = new List<Person>();
            foreach (var person in result)
            {
                string address = person.Address;
                string sPattern = "^\\d{3}\\s";

                if (Regex.IsMatch(address, sPattern, RegexOptions.IgnoreCase))
                {
                    count++;
                    addressList.Add(person);
                }
            }            
            return addressList;
        }
        public List<Person> DisplayPersonWhoseWebUrlIsLongThanThirtyFive(List<Person> personList)
        {
            //Every person whose website URL is longer than 35 characters
            var result = from person in personList
                         where person.Web.Length > 35
                         select person;        
            
            return result.ToList();
        }
        public List<Person> DisplayPersonWhoLivesInPostcode(List<Person> personList)
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
                    postalList.Add(person);
                }
            }                         
            return postalList;
        }
        public List<Person> DisplayPersonWhosePhoneNoIsLarger(List<Person> personList)
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
               return phone1List;
        }
        private static long phoneNumberConvert(string phoneNumber)
        {
            // First, remove everything except numbers
            Regex regexObj = new Regex(@"[^\d]");
            //converting to long
            return Convert.ToInt64(regexObj.Replace(phoneNumber, ""));
        }
       
    }
}