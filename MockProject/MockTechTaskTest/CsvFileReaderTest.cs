using NUnit.Framework;
using FluentAssertions;
using MockTechTask.Model;

namespace MockTechTaskTest
{
    public class Tests
    {
        
        private CsvFileReader _CsvFileReader;

        [SetUp]
        public void Setup()
        {
            _CsvFileReader = new CsvFileReader();
        }

        [Test]
        public void Count_Should_Be_Zero_For_EmptyOrNull_Input_For_DisplayPersonLivingInCountyDerbyshire()
        {
            var expectedResult = 0;
            _CsvFileReader.DisplayPersonLivingInCountyDerbyshire(" ").Should().Be(expectedResult);
            _CsvFileReader.DisplayPersonLivingInCountyDerbyshire(null).Should().Be(expectedResult);
        }
    }
}