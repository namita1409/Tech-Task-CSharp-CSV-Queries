// See https://aka.ms/new-console-template for more information
using MockTechTask.FileReader;
using MockTechTask.Model;
using MockTechTask.Query;

const string fileName = @"D:\Learning\MockProject\input\input.csv";

//Initializing the program /loading the file
ICsvFileReader csvFileReader = new CsvFileReader();
List<Person> personList = csvFileReader.FileReader(fileName);

// Asking user for the inputs
Console.WriteLine("Please choose your option  " + "\n");
Console.WriteLine("OPtion 1 : Every person who has “Esq” in their company name.");
Console.WriteLine("OPtion 2 : Every person who lives in Derbyshire");
Console.WriteLine("Option 3 :Every person whose house number is exactly three digits.");
Console.WriteLine("OPtion 4 : Every person whose website URL is longer than 35 characters");
Console.WriteLine("OPtion 5 : Every person who lives in a postcode area with a single-digit value.");
Console.WriteLine("OPtion 6 : Every person whose first phone number is numerically larger than their second phone number");

int option = Convert.ToInt32(Console.ReadLine());

Query query = new Query();
List<Person> person = new List<Person>();

switch (option) 
{
    case 1:
        person = query.PersonContainsCompanyEsq(personList);
        displayPerson(person);
        break;
    case 2:
        person = query.PersonLivingInCountyDerbyshire(personList);
        displayPerson(person);
        break;
    case 3:
        person = query.PersonWhoseHouseNoIsThreeDigit(personList);
        displayPerson(person);
        break;
    case 4:
        person = query.PersonWhoseWebUrlIsLongThanThirtyFive(personList);
        displayPerson(person);
        break;
    case 5:
        person = query.DisplayPersonWhoLivesInPostcode(personList);
        displayPerson(person);
        break;
    case 6:
        person = query.PersonWhosePhoneNo1IsLarger(personList);
        displayPerson(person);
        break;
    default:
        Console.WriteLine("invalid option, please enter the above mentioned options");
        break;

}
     static void displayPerson(List<Person> person)
     {
        Console.WriteLine($"Count { person.Count }");
        foreach (var p in person)
        {
            int index = person.IndexOf(p);
            Console.WriteLine($"{ index + 1 } { p.FirstName } { p.Postal }"); ;
        }
     }






