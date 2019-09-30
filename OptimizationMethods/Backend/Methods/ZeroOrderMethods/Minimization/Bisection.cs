using Backend.Abstractions;
using System;
using System.Collections.Generic;

namespace Backend.Methods.ZeroOrderMethods.Minimization
{
    public class Bisection : SequentialStratetyMethod
    {
        private double l = default;
        private List<double> xAverageArr = new List<double>();
        private List<double> xAverageResults = new List<double>();

        public Bisection(Interval interval, double l, FunctionHandler functionHandler)
        {
            aArr.Add(interval.Begin);
            bArr.Add(interval.End);
            this.l = l;
            this.functionHandler = functionHandler;
        }

        public override double Calculate()
        {
            return FirstStep();
        }

        private double FirstStep()
        {
            if (l <= 0)
                throw new ArgumentException("l must be more than 0");
            return SecondStep();
        }

        private double SecondStep()
        {
            k = 0;
            return ThirdStep();
        }

        private double ThirdStep()
        {
            xAverageArr.Add((aArr[k] + bArr[k]) / 2);
            lArr.Add(bArr[k] - aArr[k]);
            xAverageResults.Add(functionHandler.Calculate(xAverageArr[k]));
            return FourthStep();
        }

        private double FourthStep()
        {
            yArr.Add(aArr[k] + lArr[k] / 4);
            zArr.Add(bArr[k] - lArr[k] / 4);
            yResults.Add(functionHandler.Calculate(yArr[k]));
            zResults.Add(functionHandler.Calculate(zArr[k]));
            return FifthStep();
        }

        private double FifthStep()
        {
            if (yResults[k] < xAverageResults[k])
            {
                bArr.Add(xAverageArr[k]);
                aArr.Add(aArr[k]);
                xAverageArr.Add(yArr[k]);
                xAverageResults.Add(functionHandler.Calculate(xAverageArr[k + 1]));
                return SeventhStep();
            }
            else
            {
                return SixthStep();
            }
        }

        private double SixthStep()
        {
            if (zResults[k] < xAverageResults[k])
            {
                aArr.Add(xAverageArr[k]);
                bArr.Add(bArr[k]);
                xAverageArr.Add(zArr[k]);
                xAverageResults.Add(functionHandler.Calculate(xAverageArr[k + 1]));
                return SeventhStep();
            }
            else
            {
                aArr.Add(yArr[k]);
                bArr.Add(zArr[k]);
                xAverageArr.Add(xAverageArr[k]);
                xAverageResults.Add(functionHandler.Calculate(xAverageArr[k + 1]));
                return SeventhStep();
            }
        }

        private double SeventhStep()
        {
            lArr.Add(bArr[k + 1] - aArr[k + 1]);
            if (Math.Abs(lArr[k + 1]) <= 1)
            {
                return xAverageArr[k + 1];
            }
            else
            {
                k++;
                return FourthStep();
            }
        }
    }
}