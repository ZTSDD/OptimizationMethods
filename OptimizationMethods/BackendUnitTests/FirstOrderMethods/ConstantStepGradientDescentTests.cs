using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Methods.ZeroOrderMethods.Minimization;
using Backend;
using Backend.Methods.FirstOrderMethods;

namespace BackendUnitTests.FirstOrderMethods
{
    [TestClass]
    public class ConstantStepGradientDescentTests
    {
        [TestMethod]
        public void Calculate_ShouldReturnXPosWhereFunctionResultIsMinimum()
        {
            var functionHandler = new TwoVarsFunc("2 * x1 ^ 2 + x1 * x2 + x2 ^ 2");
            var constantStepGradientDescent = new ConstantStepGradientDescent(0.5, 1, 0.5, 0.1, 0.15, 10, 0.5, functionHandler);

            var pair = constantStepGradientDescent.Calculate();
            var result = Math.Round(functionHandler.Calculate(pair.x1, pair.x2) * 10000) / 10000;

            Assert.AreEqual(0.0075, result);
        }
    }
}