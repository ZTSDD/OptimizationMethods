using Backend.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Methods.ZeroOrderMethods.Minimization
{
    public class Dichotomy : SequentialStratetyMethod
    {
        private double e = default;
        private double l = default;

        public Dichotomy(Interval interval, double e, double l, SingleVarFunc functionHandler)
        {
            aArr.Add(interval.Begin);
            bArr.Add(interval.End);
            lArr.Add(bArr[k] - aArr[k]);
            this.e = e;
            this.l = l;
            this.functionHandler = functionHandler;
        }

        public override double Calculate()
        {
            return FirstStep();
        }

        private double FirstStep()
        {
            if (e <= 0)
                throw new ArgumentException("Eps must be more than 0.");
            if (l <= 0)
                throw new ArgumentException("l must be more than 0.");
            return SecondStep();
        }

        private double SecondStep()
        {
            k = 0;
            return ThirdStep();
        }

        private double ThirdStep()
        {
            yArr.Add((aArr[k] + bArr[k] - e) / 2);
            yResults.Add(functionHandler.Calculate(yArr[k]));
            zArr.Add((aArr[k] + bArr[k] + e) / 2);
            zResults.Add(functionHandler.Calculate(zArr[k]));
            return FourthStep();
        }

        private double FourthStep()
        {
            if (yResults[k] <= zResults[k])
            {
                aArr.Add(aArr[k]);
                bArr.Add(zArr[k]);
            }
            else
            {
                aArr.Add(yArr[k]);
                bArr.Add(bArr[k]);
            }
            return FifthStep();
        }

        private double FifthStep()
        {
            lArr.Add(bArr[k + 1] - aArr[k + 1]);
            if (Math.Abs(lArr[k + 1]) <= 1)
            {
                return (aArr[k + 1] + bArr[k + 1]) / 2;
            }
            else
            {
                k++;
                return ThirdStep();
            }
        }
    }
}