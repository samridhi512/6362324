using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            
            calc = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
            
            calc = null;
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(10, -5, 5)]
        public void Add_TwoNumbers_ReturnsCorrectSum(int a, int b, int expected)
        {
            int result = calc.Add(a, b);
            Assert.That(result, Is.EqualTo(expected),
                $"Expected {expected} but got {result} for Add({a}, {b})");
        }
    }
}
