using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Methods.ZeroOrderMethods.Minimization;
using Backend;

namespace BackendUnitTests.ZeroOrderMethods.Minimization
{
    [TestClass]
    public class GoldenRatioTests
    {
        [TestMethod]
        public void Calculate_ShouldReturnXPosWhereFunctionResultIsMinimum()
        {
            var functionHandler = new FunctionHandler("2 * x ^ 2 - 12 * x");
            var goldenRatio = new GoldenRatio(new Interval(0, 10), 1, functionHandler);

            var result = Math.Round(goldenRatio.Calculate() * 100) / 100;

            Assert.AreEqual(2.81, result);
        }
    }
}