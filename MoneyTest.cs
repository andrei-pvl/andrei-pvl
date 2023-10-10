using MoneySumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoneySum;

namespace MoneySumTest
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
        public void SumOfSum_SumOfSumForSameVal_ReturnsSumOfSum()
        {
            Money money1 = new Money(100, "USD", 1.0);
            Money money2 = new Money(25, "USD", 1.0);
            IMoney result = new Money();
            
            double expected = 125;
            double actual = result.SumOfSum(money1, money2);

            Assert.AreEqual(expected, actual);        
        }        
       
        [TestMethod]
        public void SumOfSum_SumOfSumForSameValAndZeroSum_ReturnsSumOfSum()
        {
            Money money1 = new Money(100, "USD", 1.0);
            Money money2 = new Money(0, "USD", 1.0);
            IMoney result = new Money();

            double expected = 100;
            double actual = result.SumOfSum(money1, money2);

            Assert.AreEqual(expected, actual);
        }

        
        [TestMethod]
        public void Calculate_CalculateInUsdTwoDifferentVal_ReturnsTwoSum()
        {
            Money money1 = new Money(100, "EUR", 0.85);
            Money money2 = new Money(50, "GBR", 1.35);
            IMoney result = new Money();

            double result1 = money1.Calculate(money1);
            double result2 = money2.Calculate(money2);

            double expected1 = 85;
            double actual1 = result1;

            double expected2 = 67.5;
            double actual2 = result2;

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
        

        [TestMethod]
        public void Calculate_ConvertsSumToUsd_ReturnsSumInUsd()
        {
            Money money = new Money(100, "EUR", 0.85);
            IMoney result = new Money();

            double expected = 85;
            double actual = result.Calculate(money);

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
        public void Sum_Constructor_ReturnsException()
        {
            const double SUM = -547;
            IMoney money = new Money();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => money.Sum = SUM);
        }

        [TestMethod]
        public void CursUsd_Constructor_ReturnsException()
        {
            const double CURS_USD = -1;
            IMoney money = new Money();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => money.CursUsd = CURS_USD);
        } 
    }
}
