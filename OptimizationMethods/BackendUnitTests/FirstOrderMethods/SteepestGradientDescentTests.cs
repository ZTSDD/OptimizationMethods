using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Methods.ZeroOrderMethods.Minimization;
using Backend;
using Backend.Methods.FirstOrderMethods;

namespace BackendUnitTests.FirstOrderMethods
{
    [TestClass]
    public class SteepestGradientDescentTests
    {
        // Погрешность с книгой 7%
        [TestMethod]
        public void Calculate_ShouldReturnXPosesWhereFunctionResultIsMinimum()
        {
            var functionHandler = new TwoVarsFunc("2 * x1 ^ 2 + x1 * x2 + x2 ^ 2");
            var constantSlope = new SteppestGradientDescent(0.5, 1, 0.1, 0.15, 10, functionHandler);

            var pair = constantSlope.Calculate();
            var predict = new Pair { x1 = -0.0176, x2 = 0.032 };
            var result = UnderError(pair.x1, predict.x1, 7) && UnderError(pair.x2, predict.x2, 7);
            Assert.AreEqual(true, result);
        }

        private bool UnderError(double calculated, double prediction, int errorInPercent)
        {
            if (calculated > prediction - Math.Abs(prediction / 100 * errorInPercent) &&
                calculated < prediction + Math.Abs(prediction / 100 * errorInPercent))
                return true;
            return false;
        }
    }
}