using CreditApi.Modals;
using CreditApi.Services.Interfaces;
using CreditApi.Services.LimitCalculator;
using FluentAssertions;
using NUnit.Framework;

namespace CreditApi.Tests
{
    public class LimitCalculatorServiceTests
    {
        private ILimitCalculatorService _sut;
        
        [SetUp]
        public void Setup()
        {
            _sut = new LimitCalculatorService();
        }

        [Test]
        public void Calculate_WhenScoreIsLowerThan500_LimitShouldZero()
        {
            //Arrange
            var creditParameters = new CreditParameters
            {
                Score = 400,
                Salary = 300
            };
            //Act
            var limit = _sut.Calculate(creditParameters);
            
            //Verify
            limit.Should().Be(0);
        }
        
        [Test]
        public void Calculate_WhenScoreIsGreaterThan500AndLowerThan1000AndSalaryIsLowerThan5000_LimitShould10000()
        {
            //Arrange
            var creditParameters = new CreditParameters
            {
                Score = 600,
                Salary = 300
            };
            //Act
            var limit = _sut.Calculate(creditParameters);
            
            //Verify
            limit.Should().Be(10000);
        }
        
        [Test]
        public void Calculate_WhenScoreIsGreaterThan1000_LimitShouldSalaryMultiplyCreditLimitMultiplier()
        {
            //Arrange

            const int creditLimitMultiplier = 4;
            var creditParameters = new CreditParameters
            {
                Score = 1100,
                Salary = 3000
            };
            //Act
            var limit = _sut.Calculate(creditParameters);
            
            //Verify
            limit.Should().Be(3000*creditLimitMultiplier);
        }
    }
}