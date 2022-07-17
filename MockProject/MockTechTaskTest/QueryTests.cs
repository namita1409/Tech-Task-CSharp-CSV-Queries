using NUnit.Framework;
using FluentAssertions;
using MockTechTask.Model;
using System.Collections.Generic;
using MockTechTask.Query;

namespace MockTechTaskTest
{
    public class QueryTests
    {       
        private Query Query;

        [SetUp]
        public void Setup()
        {
            Query = new Query();
        }
        [Test]
        public void DisplayPersonContainsCompanyEsq_Should_Return_CorrectResult()
        {
            var person = GetFakePerson();
            var expectedResult = new List<Person>()
            {
                 new Person
                {
                    FirstName = "Eric",
                    LastName="Rampy",
                    Company="Michael C Esq",
                    Address="9472 Lind St",
                    City = "Desborough",
                    County = "Northamptonshire",
                    Postal = "NN14 2GH",
                    Phone1 = "01969-886290",
                    Phone2 = "01545-817375",
                    Email = "erampy@rampy.co.uk",
                    Web = "http://www.thompsonmichaelcesq.co.uk"
                }
            };
            var result = Query.PersonContainsCompanyEsq(person);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void DisplayPersonLivingInCountyDerbyshire_Should_Return_CorrectResult() 
        {
            var person = GetFakePerson();
            var expectedResult = new List<Person>()
            {
                 new Person
                {
                    FirstName = "Yuette",
                    LastName="Klapec",
                    Company="Max Video",
                    Address="45 Bradfield St #166 St",
                    City = "Parwich",
                    County = "Derbyshire",
                    Postal = "DE6 1QN",
                    Phone1 = "01903-649460",
                    Phone2 = "01933-512513",
                    Email = "yuette.klapec@klapec.co.uk",
                    Web = "http://www.maxvideo.co.uk"
                }
            };
            var result = Query.PersonLivingInCountyDerbyshire(person);
          //  Assert.That(result, Is.EqualTo(expectedResult));
          result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void DisplayPersonWhoseHouseNoIsThreeDigit_Should_Return_CorrectResult()
        {
            var person = GetFakePerson();
            var expectedResult = new List<Person>()
            {
                 new Person
                {
                   FirstName = "Ulysses",
                    LastName="Mcwalters",
                    Company="Mcmahan, Ben L",
                    Address="505 Exeter Rd",
                    City = "Hawerby cum Beesby",
                    County = "Lincolnshire",
                    Postal = "DN36 5RP",
                    Phone1 = "01912-771311",
                    Phone2 = "01302-601380",
                    Email = "ulysses@hotmail.com",
                    Web = "ttp://www.mcmahanbenl.co.uk"
                }
            };
            var result = Query.PersonWhoseHouseNoIsThreeDigit(person);            
            result.Should().BeEquivalentTo(expectedResult);
        }
        [Test]
        public void DisplayPersonWhoseWebUrlIsLongThanThirtyFive_Should_Return_CorrectResult()
        {
            var person = GetFakePerson();
            var expectedResult = new List<Person>()
            {
                 new Person
                {
                    FirstName = "Charisse",
                    LastName="Spinello",
                    Company="Modern Plastics Corp",
                    Address="9165 Primrose St",
                    City = "Darnall Ward",
                    County = "Yorkshire,South",
                    Postal = "S4 7WN",
                    Phone1 = "01719-831436",
                    Phone2 = "01207-428520",
                    Email = "charisse_spinello@spinello.co.uk",
                    Web = "http://www.alandrosenburgcpapc.co.uk"
                },
                new Person
                {
                    FirstName = "Eric",
                    LastName="Rampy",
                    Company="Michael C Esq",
                    Address="9472 Lind St",
                    City = "Desborough",
                    County = "Northamptonshire",
                    Postal = "NN14 2GH",
                    Phone1 = "01969-886290",
                    Phone2 = "01545-817375",
                    Email = "erampy@rampy.co.uk",
                    Web = "http://www.thompsonmichaelcesq.co.uk"
                }
            };
            var result = Query.PersonWhoseWebUrlIsLongThanThirtyFive(person);
            result.Should().BeEquivalentTo(expectedResult);
        }
        [Test]
        public void DisplayPersonWhoLivesInPostcode_Should_Return_CorrectResult()
        {
            var person = GetFakePerson();
            var expectedResult = new List<Person>()
            {
                 new Person
                {
                    FirstName = "Yuette",
                    LastName="Klapec",
                    Company="Max Video",
                    Address="45 Bradfield St #166 St",
                    City = "Parwich",
                    County = "Derbyshire",
                    Postal = "DE6 1QN",
                    Phone1 = "01903-649460",
                    Phone2 = "01933-512513",
                    Email = "yuette.klapec@klapec.co.uk",
                    Web = "http://www.maxvideo.co.uk"
                }                 
            };
            var result = Query.DisplayPersonWhoLivesInPostcode(person);
            result.Should().BeEquivalentTo(expectedResult);
        }
        [Test]
        public void DisplayPersonWhosePhoneNoIsLarger_Should_Return_CorrectResult()
        {
            var person = GetFakePerson();
            var expectedResult = new List<Person>()
            {
                  new Person
                {
                    FirstName = "Eric",
                    LastName="Rampy",
                    Company="Michael C Esq",
                    Address="9472 Lind St",
                    City = "Desborough",
                    County = "Northamptonshire",
                    Postal = "NN14 2GH",
                    Phone1 = "01969-886290",
                    Phone2 = "01545-817375",
                    Email = "erampy@rampy.co.uk",
                    Web = "http://www.thompsonmichaelcesq.co.uk"
                },
                  new Person
                {
                    FirstName = "Charisse",
                    LastName="Spinello",
                    Company="Modern Plastics Corp",
                    Address="9165 Primrose St",
                    City = "Darnall Ward",
                    County = "Yorkshire,South",
                    Postal = "S4 7WN",
                    Phone1 = "01719-831436",
                    Phone2 = "01207-428520",
                    Email = "charisse_spinello@spinello.co.uk",
                    Web = "http://www.alandrosenburgcpapc.co.uk"
                },
                   new Person
                {
                    FirstName = "Ulysses",
                    LastName="Mcwalters",
                    Company="Mcmahan, Ben L",
                    Address="505 Exeter Rd",
                    City = "Hawerby cum Beesby",
                    County = "Lincolnshire",
                    Postal = "DN36 5RP",
                    Phone1 = "01912-771311",
                    Phone2 = "01302-601380",
                    Email = "ulysses@hotmail.com",
                    Web = "ttp://www.mcmahanbenl.co.uk"
                },
                  new Person
                {
                    FirstName = "Eric Thompson",
                    LastName="Nobel",
                    Company="Victory Coating",
                    Address="5221 Royston St",
                    City = "Eccleshall",
                    County = "Staffordshire",
                    Postal = "ST21 6GA",
                    Phone1 = "01912-146880",
                    Phone2 = "01608-570699",
                    Email = "wei_nobel@hotmail.com",
                    Web = "http://www.victorycoating.co.uk"
                },
                   new Person
                {
                    FirstName = "Evan",
                    LastName="Zigomalas",
                    Company="Cap Gemini America",
                    Address="5 Binney St",
                    City = "Abbey Ward",
                    County = "Buckinghamshire",
                    Postal = "HP11 2AX",
                    Phone1 = "01937-864715",
                    Phone2 = "01714-737668",
                    Email = "evan.zigomalas@gmail.com",
                    Web = "http://www.capgeminiamerica.co.uk"
                }

            };
            var result = Query.PersonWhosePhoneNo1IsLarger(person);
            result.Should().BeEquivalentTo(expectedResult);
        }
        private List<Person> GetFakePerson() 
        {
            return new List<Person>
            {
                new Person
                {
                    FirstName = "Eric",
                    LastName="Rampy", 
                    Company="Michael C Esq",
                    Address="9472 Lind St",
                    City = "Desborough",
                    County = "Northamptonshire",
                    Postal = "NN14 2GH",
                    Phone1 = "01969-886290",
                    Phone2 = "01545-817375",
                    Email = "erampy@rampy.co.uk",
                    Web = "http://www.thompsonmichaelcesq.co.uk"
                },
                new Person
                {
                    FirstName = "Yuette",
                    LastName="Klapec",
                    Company="Max Video",
                    Address="45 Bradfield St #166 St",
                    City = "Parwich",
                    County = "Derbyshire",
                    Postal = "DE6 1QN",
                    Phone1 = "01903-649460",
                    Phone2 = "01933-512513",
                    Email = "yuette.klapec@klapec.co.uk",
                    Web = "http://www.maxvideo.co.uk"
                },
                 new Person
                {
                    FirstName = "Charisse",
                    LastName="Spinello",
                    Company="Modern Plastics Corp",
                    Address="9165 Primrose St",
                    City = "Darnall Ward",
                    County = "Yorkshire,South",
                    Postal = "S4 7WN",
                    Phone1 = "01719-831436",
                    Phone2 = "01207-428520",
                    Email = "charisse_spinello@spinello.co.uk",
                    Web = "http://www.alandrosenburgcpapc.co.uk"
                },
                 new Person
                {
                    FirstName = "Ulysses",
                    LastName="Mcwalters",
                    Company="Mcmahan, Ben L",
                    Address="505 Exeter Rd",
                    City = "Hawerby cum Beesby",
                    County = "Lincolnshire",
                    Postal = "DN36 5RP",
                    Phone1 = "01912-771311",
                    Phone2 = "01302-601380",
                    Email = "ulysses@hotmail.com",
                    Web = "ttp://www.mcmahanbenl.co.uk"
                },
                  new Person
                {
                    FirstName = "Eric Thompson",
                    LastName="Nobel",
                    Company="Victory Coating",
                    Address="5221 Royston St",
                    City = "Eccleshall",
                    County = "Staffordshire",
                    Postal = "ST21 6GA",
                    Phone1 = "01912-146880",
                    Phone2 = "01608-570699",
                    Email = "wei_nobel@hotmail.com",
                    Web = "http://www.victorycoating.co.uk"
                },
                   new Person
                {
                    FirstName = "Evan",
                    LastName="Zigomalas",
                    Company="Cap Gemini America",
                    Address="5 Binney St",
                    City = "Abbey Ward",
                    County = "Buckinghamshire",
                    Postal = "HP11 2AX",
                    Phone1 = "01937-864715",
                    Phone2 = "01714-737668",
                    Email = "evan.zigomalas@gmail.com",
                    Web = "http://www.capgeminiamerica.co.uk"
                }
            };
        }
    }
}