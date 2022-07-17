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
    public class CsvFileReader : ICsvFileReader
    {                   
        public List<Person> FileReader(string fileName)
        {
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
                    p.Email = line[i + 9];
                    p.Web = line[i + 10];
                    personList.Add(p);
                }
            }
            return personList;
        }   
         
    }
}

         
                    
    

