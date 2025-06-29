using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private CustomerCommLib.CustomerComm _customerComm;

        private Mock<IMailSender> _mockMailSender;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();
            _mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);

        }
        [TestCase("cust123@abc.com", "Some Message", ExpectedResult = true)]
        [TestCase("hello@world.com", "Welcome!", ExpectedResult = true)]
        public bool SendMailToCustomer_TestCases(string to, string message)
        {
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender.Setup(m => m.SendMail(to, message)).Returns(true);

            var customerComm = new CustomerCommLib.CustomerComm(mockMailSender.Object);
            return _customerComm.SendMailToCustomer("test@example.com", "Hello!");

        }


        [Test]
        public void SendMailToCustomer_ShouldReturnTrue()
        {
            var result = _customerComm.SendMailToCustomer("test@example.com", "Hello!");

            Assert.That(result, Is.True);
        }
    }
}