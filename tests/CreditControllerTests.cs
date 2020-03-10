using System.Threading.Tasks;
using CreditApi.Controllers;
using CreditApi.Enums;
using CreditApi.Modals;
using CreditApi.Requests;
using CreditApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CreditApi.Tests
{
    public class Tests
    {
        
        private Mock<CreditService> _mockCreditService;
        private CreditController _sut;
        
        [SetUp]
        public void Setup()
        {
            _mockCreditService = new Mock<CreditService>();
            _sut = new CreditController(_mockCreditService.Object);
        }

        [Test]
        public void Apply_WhenCreditResultIsNotApplied_ShouldReturnBadRequest()
        {
            // Arrange
            var creditResult = new CreditResult
            {
                Status = CreditStatus.NotApplied
            };

            _mockCreditService.Setup(x => x.Apply(It.IsAny<CreditApplyRequest>())).Returns(Task.FromResult(creditResult));

            // Act
            var result = _sut.Apply(It.IsAny<CreditApplyRequest>()).Result;
            
            //Verify
            Assert.IsInstanceOf(typeof(BadRequestResult),result);
        }
    }
}