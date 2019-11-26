using Backend.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Methods.FirstOrderMethods
{
    public class SteppestGradientDescent : TwoVarMethod
    {
        double dt;

        public SteppestGradientDescent(double x1, double x2, double e1, double e2, int M, TwoVarsFunc func)
        {
            this.functionHandler = func;
            this.xPairs.Add(new Pair { x1 = x1, x2 = x2 });
            this.e1 = e1;
            this.e2 = e2;
            this.M = M;
        }

        public override Pair Calculate()
        {
            return FirstStep();
            throw new NotImplementedException();
        }

        private Pair FirstStep()
        {
            return SecondStep();
            throw new NotImplementedException();
        }

        private Pair SecondStep()
        {
            k = 0;
            return ThirdStep();
            throw new NotImplementedException();
        }

        private Pair ThirdStep()
        {
            AddDeltaFResult(k, new Pair
            {
                x1 = functionHandler.CalculateX1Grad(xPairs[k].x1, xPairs[k].x2),
                x2 = functionHandler.CalculateX2Grad(xPairs[k].x1, xPairs[k].x2),
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
            else
            {
                return FifthStep();
            }
            throw new NotImplementedException();
        }

        private Pair FifthStep()
        {
            if (k >= M)
            {
                return xPairs[k];
            }
            else
            {
                return SixthStep();
            }
            throw new NotImplementedException();
        }

        private Pair SixthStep()
        {
            dt = 
                // Числитель
                (
                    Math.Pow((4 * xPairs[k].x1 + xPairs[k].x2), 2) + 
                    Math.Pow((xPairs[k].x1 + 2 * xPairs[k].x2), 2)
                )
                /
                // Знаменатель
                (
                    4 * Math.Pow((4 * xPairs[k].x1 + xPairs[k].x2), 2) +
                    2 * (4 * xPairs[k].x1 + xPairs[k].x2) *
                    (xPairs[k].x1 + 2 * xPairs[k].x2) +
                    2 * Math.Pow((xPairs[k].x1 + 2 * xPairs[k].x2), 2)
                );
            return SeventhStep();
            throw new NotImplementedException();
        }

        private Pair SeventhStep()
        {
            AddXPair(k + 1, new Pair
            {
                x1 = xPairs[k].x1 - dt * deltaFResults[k].x1,
                x2 = xPairs[k].x2 - dt * deltaFResults[k].x2,
            });
            return EighthStep();
            throw new NotImplementedException();
        }

        private Pair EighthStep()
        {
            if (
                    Math.Abs(Quadratic(new Pair { x1 = xPairs[k+1].x1 + xPairs[k].x1, x2 = xPairs[k+1].x2 + xPairs[k].x2 })) < e2 &&
                    Math.Abs(functionHandler.Calculate(xPairs[k+1].x1, xPairs[k+1].x2) - functionHandler.Calculate(xPairs[k].x1, xPairs[k].x2)) < e2
               )
            {
                return xPairs[k + 1];
            }
            else
            {
                k++;
                return ThirdStep();
            }
            throw new NotImplementedException();
        }
    }
}
