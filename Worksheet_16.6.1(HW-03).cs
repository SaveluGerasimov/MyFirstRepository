using NUnit.Framework;
using Practices; 

namespace Practices.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Additional_ShouldReturnSumOfAAndB()
        {
            Assert.AreEqual(5, calculator.Additional(2, 3));
            Assert.AreEqual(0, calculator.Additional(-1, 1));
            Assert.AreEqual(10, calculator.Additional(7, 3));
        }

        [Test]
        public void Subtraction_ShouldReturnDifferenceOfAAndB()
        {
            Assert.AreEqual(1, calculator.Subtraction(3, 2));
            Assert.AreEqual(-2, calculator.Subtraction(-1, 1));
            Assert.AreEqual(0, calculator.Subtraction(5, 5));
        }

        [Test]
        public void Miltiplication_ShouldReturnProductOfAAndB()
        {
            Assert.AreEqual(6, calculator.Miltiplication(2, 3));
            Assert.AreEqual(-4, calculator.Miltiplication(-2, 2));
            Assert.AreEqual(25, calculator.Miltiplication(5, 5));
        }

        [Test]
        public void Division_ShouldReturnQuotientOfAAndB()
        {
            Assert.AreEqual(2, calculator.Division(4, 2));
            Assert.AreEqual(-3, calculator.Division(-9, 3));
        }

        [Test]
        public void Division_ByZero_ShouldThrowDivideByZeroException()
        {
            Assert.Throws<System.DivideByZeroException>(() => calculator.Division(1, 0));
        }
    }
}
