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
    }

    public class StringCalculator
    {
        public static int Add(string value)
        {
            if (IsValueEmpty(value))
                return HandleEmptyValue();

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