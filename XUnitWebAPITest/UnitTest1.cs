using System;
using Xunit;
using WebAPI.Controllers;

namespace XUnitWebAPITest
{
    public class UnitTest1
    {
        [Fact]
        public void Test_For_Blank_Call()
        {
            ValuesController valueController = new ValuesController();

            var actual = valueController.Get();
            var expected = "Enter hello Or hi";
            Assert.Equal(expected, actual.Value);
        }


        [Fact]
        public void Test_For_Hi()
        {
            ValuesController valueController = new ValuesController();

            var actual = valueController.Get("hi");
            var expected = "hello";
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public void Test_For_Hello()
        {
            ValuesController valueController = new ValuesController();

            var actual = valueController.Get("hello");
            var expected = "hi";
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public void Test_For_Randomn_String()
        {
            ValuesController valueController = new ValuesController();

            var actual = valueController.Get("Something");
            var expected = "Enter hello Or hi";
            Assert.Equal(expected, actual.Value);
        }
    }
}
