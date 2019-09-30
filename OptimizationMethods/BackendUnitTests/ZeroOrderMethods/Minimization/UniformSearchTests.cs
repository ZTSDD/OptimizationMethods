using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Methods.ZeroOrderMethods.Minimization;
using Backend;

namespace BackendUnitTests.ZeroOrderMethods.Minimization
{
    [TestClass]
    public class UniformSearchTests
    {
        [TestMethod]
        public void Calculate_ShouldReturnXPosWhereFunctionResultIsMinimum()
        {
            var functionHandler = new FunctionHandler("2 * x ^ 2 - 12 * x");
            var uniformSearch = new UniformSearch(0, 10, 9, functionHandler);

            var result = uniformSearch.Calculate();

            Assert.AreEqual(3, result);
        }
    }
}