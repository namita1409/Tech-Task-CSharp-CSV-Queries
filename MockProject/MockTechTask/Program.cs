// See https://aka.ms/new-console-template for more information
using MockTechTask.Model;

const string fileName = @"D:\Learning\MockProject\input\input.csv";
CsvFileReader csvFileReader = new CsvFileReader();
List<Person> personList = csvFileReader.FileReader(fileName);

Console.WriteLine("Please choose your option  " + "\n");
Console.WriteLine("OPtion 1 : Every person who has “Esq” in their company name.");
Console.WriteLine("OPtion 2 : Every person who lives in Derbyshire");
Console.WriteLine("Option 3 :Every person whose house number is exactly three digits.");
Console.WriteLine("OPtion 4 : Every person whose website URL is longer than 35 characters");
Console.WriteLine("OPtion 5 : Every person who lives in a postcode area with a single-digit value.");
Console.WriteLine("OPtion 6 : Every person whose first phone number is numerically larger than their second phone number");

int option = Convert.ToInt32(Console.ReadLine());

Query query = new Query();

switch (option) {
    case 1:
        query.DisplayPersonContainsCompanyEsq(personList);
        break;
    case 2:
        int count = query.DisplayPersonLivingInCountyDerbyshire(personList);
        break;
    case 3:
        query.DisplayPersonWhoseHouseNoIsDigit(personList);
        break;
    case 4:
        query.DisplayPersonWhoseWebUrlIsLongThanThirtyFive(personList);
        break;
    case 5:
        query.DisplayPersonWhoLivesInPostcode(personList);
        break;
    case 6:
        query.DisplayPersonWhosePhoneNoIsLarger(personList);
        break;
    default:
        Console.WriteLine("invalid option, please enter the above mentioned options");
        break;

}







