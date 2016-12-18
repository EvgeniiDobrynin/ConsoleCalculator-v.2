using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OopCalculator;
using System.Threading;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator calculator;
        string delimiter;

        [TestInitialize]
        public void TestInitialize()
        {
            calculator = new Calculator();
            delimiter = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }
        
        [TestMethod]
        public void Input1()
        {
            Assert.AreEqual(calculator.Calculate("1"), "1");
        }

        [TestMethod]
        public void Input2()
        {
            Assert.AreEqual(calculator.Calculate("2"), "2");
        }

        [TestMethod]
        public void Input12()
        {
            Assert.AreEqual(calculator.Calculate("12"), "12");
        }
        
        [TestMethod]
        public void EmptyInput()
        {
            Assert.AreEqual(calculator.Calculate(""), "");
        }

        [TestMethod]
        public void NumberWithCommaDelimiter()
        {
            Assert.AreEqual(calculator.Calculate("2,3"), "2" + delimiter + "3");
        }

        [TestMethod]
        public void NumberWithPointDelimiter()
        {
            Assert.AreEqual(calculator.Calculate("2.3"), "2" + delimiter + "3");
        }

        [TestMethod]
        public void Sum()
        {
            Assert.AreEqual(calculator.Calculate("2+3"), "5");
        }

        [TestMethod]
        public void Subtract()
        {
            Assert.AreEqual(calculator.Calculate("2-3"), "-1");
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(calculator.Calculate("4*3"), "12");
        }

        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(calculator.Calculate("12/3"), "4");
        }

        [TestMethod]
        public void Sums2()
        {
            Assert.AreEqual(calculator.Calculate("2+3+4"), "9");
        }

        [TestMethod]
        public void FirstlySumThenMultiply()
        {
            Assert.AreEqual(calculator.Calculate("2+3*4"), "14");
        }

        [TestMethod]
        public void FirstlyMultiplyThenSum()
        {
            Assert.AreEqual(calculator.Calculate("2*3+4"), "10");
        }

        [TestMethod]
        public void NumberInBrackets()
        {
            Assert.AreEqual(calculator.Calculate("(2)"), "2");
        }

        [TestMethod]
        public void SumInBrackets()
        {
            Assert.AreEqual(calculator.Calculate("(2+3)"), "5");
        }

        [TestMethod]
        public void ExpressionOutsideTheExpressionInBrackets()
        {
            Assert.AreEqual(calculator.Calculate("5*(2+3*4)/4"), "17" + delimiter + "5");
        }

        [TestMethod]
        public void ExpressionOutsideTheExpressionInDoubleBrackets()
        {
            Assert.AreEqual(calculator.Calculate("5*((2+3*4)/4)"), "17" + delimiter + "5");
        }
    }
}
