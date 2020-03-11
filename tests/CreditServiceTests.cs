using System.Threading.Tasks;
using AutoFixture;
using CreditApi.Controllers;
using CreditApi.Modals;
using CreditApi.Repositories;
using CreditApi.Requests;
using CreditApi.Services;
using CreditApi.Services.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CreditApi.Tests
{
    public class CreditServiceTests
    {
        private Mock<ICreditScoreService> _mockCreditScoreService;
        private Mock<ILimitCalculatorService> _mockLimitCalculator;
        private Mock<ICreditRepository> _mockCreditRepository;
        private Fixture _fixture;
        
        private CreditService _sut;
        
        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockCreditRepository = new Mock<ICreditRepository>();
            _mockLimitCalculator = new Mock<ILimitCalculatorService>();
            _mockCreditScoreService = new Mock<ICreditScoreService>();
            
            _sut = new CreditService(_mockCreditScoreService.Object,_mockLimitCalculator.Object,_mockCreditRepository.Object);
        }

        [Test]
        public async Task Apply_WhenLimitIsZero_ShouldReturnFail()
        {
            //Arrange
            var creditApplyRequest = _fixture.Build<CreditApplyRequest>().Create();
            _mockCreditScoreService.Setup(x => x.GetScore(creditApplyRequest.IdentificationNumber)).Returns(Task.FromResult<long>(2));
            _mockLimitCalculator.Setup(x => x.Calculate(It.IsAny<CreditParameters>())).Returns(0);
            //Act
            var result = await _sut.Apply(creditApplyRequest);

            //Verify
            result.Should().BeEquivalentTo(CreditResult.Fail());
        }
        
        [Test]
        public async Task Apply_WhenLimitIsGreaterThanZero_ShouldReturnSuccess()
        {
            //Arrange
            var limit = 12;
            var creditApplyRequest = _fixture.Build<CreditApplyRequest>().Create();
            _mockCreditScoreService.Setup(x => x.GetScore(creditApplyRequest.IdentificationNumber)).Returns(Task.FromResult<long>(2));
            _mockLimitCalculator.Setup(x => x.Calculate(It.IsAny<CreditParameters>())).Returns(limit);
            //Act
            var result = await _sut.Apply(creditApplyRequest);

            //Verify
            result.Should().BeEquivalentTo(CreditResult.Success(limit));
        }
    }
}