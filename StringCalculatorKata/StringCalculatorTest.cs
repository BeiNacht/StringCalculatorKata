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
    }

    public class StringCalculator
    {
        public static int Add(string value)
        {
            if (IsValueEmpty(value))
                return HandleEmptyValue();

            char[] delimiter = new char[] {',', '\n'};

            if (delimiter.Any(value.Contains))
            {
                var numbers = value.Split(delimiter);
                return HandleOneNumber(numbers[0]) + HandleOneNumber(numbers[1]);
            }

            return HandleOneNumber(value);
        }

        static int HandleOneNumber(string value)
        {
            return int.Parse(value);
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