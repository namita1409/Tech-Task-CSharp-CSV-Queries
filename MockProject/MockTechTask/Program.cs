// See https://aka.ms/new-console-template for more information
using MockTechTask.Model;

CsvFileReader csvFileReader = new CsvFileReader();
csvFileReader.FileReader();

Console.WriteLine("Please choose your option  " + "\n");
Console.WriteLine("OPtion1 : Every person who has “Esq” in their company name.");
Console.WriteLine("OPtion2 : Every person who lives in Derbyshire");
Console.WriteLine("Option 3 :Every person whose house number is exactly three digits.");
Console.WriteLine("OPtion4 : Every person whose website URL is longer than 35 characters");
Console.WriteLine("OPtion5 : Every person who lives in a postcode area with a single-digit value.");
Console.WriteLine("OPtion6 : Every person whose first phone number is numerically larger than their second phone number");

int option = Convert.ToInt32(Console.ReadLine());
switch (option) {
    case 1:
        csvFileReader.DisplayPersonContainsCompanyEsq("Esq");
        break;
    case 2:
        csvFileReader.DisplayPersonLivingInCountyDerbyshire("Derbyshire");
        break;
    case 3:
        csvFileReader.DisplayPersonWhoseHouseNoIsDigit();
        break;
    case 4:
        csvFileReader.DisplayPersonWhoseWebUrlIsLongThanThirtyFive();
        break;
    case 5:
        csvFileReader.DisplayPersonWhoLivesInPostcode();
        break;
    case 6:
        csvFileReader.DisplayPersonWhosePhoneNoIsLarger();
        break;
    default:
             Console.WriteLine("option not valid, please enter the above mentioned options");
             break;

}







