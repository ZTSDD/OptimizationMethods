using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Methods.ZeroOrderMethods.Minimization;
using Backend;

namespace BackendUnitTests.ZeroOrderMethods.Minimization
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void Calculate_ShouldReturnXPosWhereFunctionResultIsMinimum()
        {
            var functionHandler = new SingleVarFunc("2 * x ^ 2 - 12 * x");
            var fibonacci = new Fibonacci(new Interval(0, 10), 0.01, 1, functionHandler);

            var result = Math.Round(fibonacci.Calculate() * 10000) / 10000;

            Assert.AreEqual(2.6923, result);
        }
    }
}