using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Methods.ZeroOrderMethods.Minimization;
using Backend;

namespace BackendUnitTests.ZeroOrderMethods.Minimization
{
    [TestClass]
    public class DichotomyTests
    {
        [TestMethod]
        public void Calculate_ShouldReturnXPosWhereFunctionResultIsMinimum()
        {
            var functionHandler = new SingleVarFunc("2 * x ^ 2 - 12 * x");
            var dichotomy = new Dichotomy(new Interval(0, 10), 0.2, 1, functionHandler);

            var result = Math.Round(dichotomy.Calculate() * 1000) / 1000;

            Assert.AreEqual(2.856, result);
        }
    }
}