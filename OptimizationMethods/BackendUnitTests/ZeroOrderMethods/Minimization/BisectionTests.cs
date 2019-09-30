using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Methods.ZeroOrderMethods.Minimization;
using Backend;

namespace BackendUnitTests.ZeroOrderMethods.Minimization
{
    [TestClass]
    public class BisectionTests
    {
        [TestMethod]
        public void Calculate_ShouldReturnXPosWhereFunctionResultIsMinimum()
        {
            var functionHandler = new FunctionHandler("2 * x ^ 2 - 12 * x");
            var bisection = new Bisection(new Interval(0, 10), 1, functionHandler);

            var result = Math.Round(bisection.Calculate() * 1000) / 1000;

            Assert.AreEqual(3.125, result);
        }
    }
}