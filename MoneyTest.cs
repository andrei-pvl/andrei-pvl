using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoneySumm;

namespace MoneySummTest
{
    [TestClass]
    public class MoneyTest
    {
        [TestMethod]
        public void Equals_EqualsTwoSumForSameVal_ReturnsBool()
        {
            Money money1 = new Money(100, "USD", 1.0);
            Money money2 = new Money(100, "USD", 1.0);

            bool expected = true;
            bool actual = money1.Equals(money2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_EqualsTwoSumForDifferentVal_ReturnsBool()
        {
            Money money1 = new Money(100, "USD", 1.0);
            Money money2 = new Money(100, "EUR", 0.85);

            bool expected = false;
            bool actual = money1.Equals(money2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_EqualsSumAndNullSum_ReturnsBool()
        {
            Money money = new Money(100, "USD", 1.0);

            bool expected = false;
            bool actual = money.Equals(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddSumForSameValSum_ReturnsSumOfSum()
        {
            Money money1 = new Money(100, "USD", 1.0);
            Money money2 = new Money(25, "USD", 1.0);
            Money result = new Money(125, "USD", 1.0);

            Money expected = result;
            Money actual = money2.Add(money1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddSumForDifferentValSum_ReturnsSumOfSum()
        {
            Money money1 = new Money(50, "GBR", 1.35);
            Money money2 = new Money(25, "EUR", 0.85);
            Money result = new Money(88.75, "USD");

            Money expected = result;
            Money actual = money2.Add(money1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Add_AddSumForSameValAndZeroSum_ReturnsSumOfSum()
        {
            Money money1 = new Money(100, "USD", 1.0);
            Money money2 = new Money(0, "USD", 1.0);
            Money result = new Money(100, "USD", 1.0);

            Money expected = result;
            Money actual = money2.Add(money1);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Calculate_ConvertsSumToUsd_ReturnsSumInUsd()
        {
            Money money = new Money(100, "EUR", 0.85);
            Money result = new Money(85, "USD", 1.0);

            Money expected = result;
            Money actual = money.Calculate(money);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void ToString_ConvertsSumToString_ReturnsString()
        {
            Money money = new Money(5, "USD", 1.0);

            string expected = "5 USD";
            string actual = money.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sum_IncorrectSum_ThrowException()
        {
            Money money1 = new Money(-62, "USD", 1.0);
            Money money2 = null;

            money2.Add(money1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CursUsd_IncorrectCursUsd_ThrowException()
        {
            Money money1 = new Money(26, "EUR", -68);
        }
    }
}
