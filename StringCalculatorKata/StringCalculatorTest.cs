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
    }

    public class StringCalculator
    {
        public static int Add(string value)
        {
            return 0;
        }
    }
}