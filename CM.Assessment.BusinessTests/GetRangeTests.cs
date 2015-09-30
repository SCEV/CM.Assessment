using Microsoft.VisualStudio.TestTools.UnitTesting;
using CM.Assessment.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CM.Assessment.Business.Tests
{
    [TestClass()]
    public class GetRangeTests
    {
        [TestMethod()]
        public void DivisableBy15TestResult()
        {
            int minValue = 1;
            int maxValue = 100;
            string value1 = "Fizz";
            string value2 = "Buzz";

            int i = minValue;

            GetRange range = new GetRange();
            range.ShowOutput += (s, e) =>
            {
                if (i % 15 == 0)
                    Assert.AreEqual(string.Format("{0} {1}", value1, value2), e.Trim());
                i++;
            };

            range.Run(minValue, maxValue, value1, value2);
        }

        [TestMethod()]
        public void ExpectedTestResult()
        {
            int minValue = 1; // 0 will cause the Assert.AreEqual (3,5 & 15) to fail, this is expected with this test.  Wrote special test below - ZeroCheck
            int maxValue = 1500;
            string value1 = "Fizz";
            string value2 = "Buzz";

            int i = minValue;

            GetRange range = new GetRange();
            range.ShowOutput += (s, e) =>
            {
                if (i % 15 == 0)
                    Assert.AreEqual(string.Format("{0} {1}", value1, value2), e.Trim());
                else if (i % 3 == 0)
                    Assert.AreEqual(value1, e.Trim());
                else if (i % 5 == 0)
                    Assert.AreEqual(value2, e.Trim());
                else
                    Assert.AreEqual(i.ToString(), e);
                i++;
            };

            range.Run(minValue, maxValue, value1, value2);
            Assert.IsTrue(range.LoopedTo == maxValue);
        }

        [TestMethod()]
        public void WeReachedMaxLoop()
        {
            int maxValue = 30;
            GetRange range = new GetRange();

            var input = new RunArgs(15, maxValue, "Fizz", "Buzz");
            range.Run(input);

            Assert.IsTrue(range.LoopedTo == maxValue);
        }

        [TestMethod()]
        public void ZeroCheck()
        {
            // 0 is NOT DivisableBy 3,5 and 15 but the C# % operator handles 0 % n, and always returns 0, so need to test that we've handeld this case in our code.
            int minValue = 0;
            int maxValue = 1;
            int i = minValue;

            GetRange range = new GetRange();
            range.ShowOutput += (s, e) =>
            {
                if (i == 0)
                    Assert.AreEqual(i.ToString(), e);
                i++;
            };

            var input = new RunArgs(minValue, maxValue, "Fizz", "Buzz");
            range.Run(input);
        }
    }
}