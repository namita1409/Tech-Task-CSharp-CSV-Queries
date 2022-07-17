using NUnit.Framework;
using FluentAssertions;
using MockTechTask.Model;
using System.Collections.Generic;

namespace MockTechTaskTest
{
    public class Tests
    {
        
        private Query _Query;

        [SetUp]
        public void Setup()
        {
            _Query = new Query();
        }

        [Test]
        public void Count_Should_Be_Zero_For_EmptyOrNull_Input_For_DisplayPersonLivingInCountyDerbyshire()
        {
            var expectedResult = 0;
           // _Query.DisplayPersonLivingInCountyDerbyshire("").Should().Be(expectedResult);
//_Query.DisplayPersonLivingInCountyDerbyshire(null).Should().Be(expectedResult);
        }
        private List<Person> GetFakePerson() 
        {
            return new List<Person>
            {
                new Person
                {
                    FirstName = "",LastName="", Company="", Address="", City = "",
                    County = "", Postal = "", Phone1 = "",Phone2 = "",Email="",Web=""
                }
            };
        }
    }
}