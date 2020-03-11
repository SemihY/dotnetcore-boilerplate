using System.Threading.Tasks;
using CreditApi.Controllers;
using CreditApi.Enums;
using CreditApi.Modals;
using CreditApi.Repositories.Entities;
using CreditApi.Requests;
using CreditApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CreditApi.Tests
{
    public class Tests
    {
        
        private Mock<ICreditService> _mockCreditService;
        private CreditController _sut;
        
        [SetUp]
        public void Setup()
        {
            _mockCreditService = new Mock<ICreditService>();
            _sut = new CreditController(_mockCreditService.Object);
        }

        [Test]
        public async Task Apply_WhenCreditResultIsNotApplied_ShouldReturnBadRequest()
        {
            // Arrange
            var creditResult = CreditResult.Fail();

            _mockCreditService.Setup(x => x.Apply(It.IsAny<CreditApplyRequest>())).Returns(Task.FromResult(creditResult));

            // Act
            var result = await _sut.Apply(It.IsAny<CreditApplyRequest>());
            
            //Verify
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        
        [Test]
        public async Task Apply_WhenCreditResultIsApplied_ShouldReturnOkRequest()
        {
            // Arrange
            var creditResult = CreditResult.Success(It.IsAny<decimal>());

            _mockCreditService.Setup(x => x.Apply(It.IsAny<CreditApplyRequest>())).Returns(Task.FromResult(creditResult));

            // Act
            var result = await _sut.Apply(It.IsAny<CreditApplyRequest>());
            
            //Verify
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}