using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Methods.FirstOrderMethods
{
    public class ConstantStepGradientDescent : IPairMethod
    {
        private int k = default;
        private double e = default;
        private double e1 = default;
        private double e2 = default;
        private List<Pair> deltaFResults = default;
        private List<Pair> xPairs = default;
        private TwoVarsFunc functionHandler = default;
        private int M = default;
        private double tk = default;

        public ConstantStepGradientDescent(double x1, double x2, double e, double e1, double e2, int M, double tk, TwoVarsFunc twoVarsFunc)
        {
            this.xPairs = new List<Pair>();
            this.deltaFResults = new List<Pair>();
            this.functionHandler = twoVarsFunc;
            this.xPairs.Add(new Pair() { x1 = x1, x2 = x2 });
            this.e = e;
            this.e1 = e1;
            this.e2 = e2;
            this.M = M;
            this.tk = tk;
        }

        private void AddXPair(int pos, Pair pair)
        {
            while (xPairs.Count - 1 < pos)
            {
                xPairs.Add(pair);
            }
            xPairs[pos] = pair;
        }

        public Pair Calculate()
        {
            return FirstStep();
        }

        private Pair FirstStep()
        {
            if (e1 <= 0 || e1 >= 1)
                throw new ArgumentException("e1 must be in the range (0,1)");
            if (e2 <= 0)
                throw new ArgumentException("e2 must be greater than 0");
            return SecondStep();
        }

        private Pair SecondStep()
        {
            k = 0;
            return ThirdStep();
        }

        private Pair ThirdStep()
        {
            deltaFResults.Add(new Pair
            {
                x1 = functionHandler.CalculateX1Grad(xPairs[k].x1, xPairs[k].x2),
                x2 = functionHandler.CalculateX2Grad(xPairs[k].x1, xPairs[k].x2)
            });
            return FourthStep();
            throw new NotImplementedException();
        }

        private Pair FourthStep()
        {
            if (Quadratic(deltaFResults[k]) < e1)
            {
                return xPairs[k];
            }
            return FifthStep();
        }

        private Pair FifthStep()
        {
            if (k >= M)
            {
                return xPairs[k];
            }
            return SixthStep();
        }

        private Pair SixthStep()
        {
            return SeventhStep();
        }

        private Pair SeventhStep()
        {
            AddXPair(k + 1, new Pair()
            {
                x1 = xPairs[k].x1 - deltaFResults[k].x1 * tk,
                x2 = xPairs[k].x2 - deltaFResults[k].x2 * tk
            });
            return EighthStep();
        }

        private Pair EighthStep()
        {
            if (functionHandler.Calculate(xPairs[k + 1].x1, xPairs[k + 1].x2) - functionHandler.Calculate(xPairs[k].x1, xPairs[k].x2) < 0 ||
                functionHandler.Calculate(xPairs[k + 1].x1, xPairs[k + 1].x2) - functionHandler.Calculate(xPairs[k].x1, xPairs[k].x2) < -e * Math.Pow(Quadratic(deltaFResults[k]), 2))
            {
                return NinthStep();
            }
            tk /= 2.0;
            return SeventhStep();
        }

        private Pair NinthStep()
        {
            if (Quadratic(new Pair() { x1 = xPairs[k + 1].x1 - xPairs[k].x1, x2 = xPairs[k + 1].x2 - xPairs[k].x2 }) < e2 &&
                Quadratic(new Pair() { x1 = functionHandler.Calculate(xPairs[k + 1].x1, xPairs[k + 1].x2) - functionHandler.Calculate(xPairs[k].x1, xPairs[k].x2) }) < e2 &&
                Quadratic(new Pair() { x1 = xPairs[k].x1 - xPairs[k - 1].x1, x2 = xPairs[k].x2 - xPairs[k - 1].x2 }) < e2 &&
                Quadratic(new Pair() { x1 = functionHandler.Calculate(xPairs[k].x1, xPairs[k].x2) - functionHandler.Calculate(xPairs[k - 1].x1, xPairs[k - 1].x2) }) < e2)
            {
                return xPairs[k + 1];
            }
            k++;
            return ThirdStep();
        }

        private double Quadratic(Pair pair) => Math.Sqrt(
            Math.Pow(pair.x1, 2) + Math.Pow(pair.x2, 2));
    }
}
