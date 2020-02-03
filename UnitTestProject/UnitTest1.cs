using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FizzBizzTest.Models.FizzBuzz fizz = new FizzBizzTest.Models.FizzBuzz();
            Random rnd = new Random();
            int n = rnd.Next(1, 100);
            fizz.FizzBuzzToList(n);
        }
    }
}
