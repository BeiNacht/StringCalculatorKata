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

        [Test]
        public void Add_OneNumberString_ReturnNumber()
        {
            int result = StringCalculator.Add("1");
            Assert.AreEqual(result, 1);
        }
    }

    public class StringCalculator
    {
        public static int Add(string value)
        {
            if (value == "")
                return 0;

            return 1;
        }
    }
}