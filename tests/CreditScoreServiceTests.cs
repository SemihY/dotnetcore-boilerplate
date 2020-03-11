using System.Threading.Tasks;
using CreditApi.Services;
using FluentAssertions;
using NUnit.Framework;

namespace CreditApi.Tests
{
    public class CreditScoreServiceTests
    {

        private CreditScoreService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new CreditScoreService();
        }

        [Test]
        public async Task TrueStory()
        {
            //Arrange
            var identificationNumber = 7;
            
            //Act
            var result = await _sut.GetScore(identificationNumber);
            
            //Verify
            result.Should().BePositive();
        }
    }
}