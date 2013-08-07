using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTest
    {
        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            int result = StringCalculator.Add("");
            Assert.AreEqual(result, 0);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Add_OneNumberString_ReturnNumber(string value, int expected)
        {
            int result = StringCalculator.Add(value);
            Assert.AreEqual(result, expected);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,3", 5)]
        public void Add_TwoNumberString_ReturnSum(string value, int expected)
        {
            int result = StringCalculator.Add(value);
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Add_TwoNumberStringWithNewLineDelimiter_ReturnSum()
        {
            int result = StringCalculator.Add("1\n2");
            Assert.AreEqual(result, 3);
        }

        [Test]
        public void Add_MultipleNumberString_ReturnSum()
        {
            int result = StringCalculator.Add("1,2,3");
            Assert.AreEqual(result, 6);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_NegativNumber_ThrowException()
        {
            int result = StringCalculator.Add("-1");
        }

        [Test]
        public void Add_NumberOver1000_IngnoreThem()
        {
            int result = StringCalculator.Add("1,1001");
            Assert.AreEqual(result,1);
        }
    }

    public class StringCalculator
    {
        public static int Add(string value)
        {
            if (IsValueEmpty(value))
                return HandleEmptyValue();

            var delimiter = new char[] {',', '\n'};

            if (HasMultipleNumbers(value, delimiter))
                return HandleMultipleNumbers(value, delimiter);

            return HandleOneNumber(value);
        }

        static int HandleMultipleNumbers(string value, char[] delimiter)
        {
            return value.Split(delimiter).Sum(number => HandleOneNumber(number));
        }

        static bool HasMultipleNumbers(string value, IEnumerable<char> delimiter)
        {
            return delimiter.Any(value.Contains);
        }

        static int HandleOneNumber(string value)
        {
            int number = int.Parse(value);
            if (IsNumberNegativ(number))
                HandleNegativeNumber();

            if (IsNumberOver1000(number))
                return IgnoreNumber();

            return number;
        }

        static int IgnoreNumber()
        {
            return 0;
        }

        static bool IsNumberOver1000(int number)
        {
            return number > 1000;
        }

        static void HandleNegativeNumber()
        {
            throw new ArgumentOutOfRangeException();
        }

        static bool IsNumberNegativ(int number)
        {
            return number < 0;
        }

        static int HandleEmptyValue()
        {
            return 0;
        }

        static bool IsValueEmpty(string value)
        {
            return value == "";
        }
    }
}