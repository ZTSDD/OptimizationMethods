using Backend.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Methods.ZeroOrderMethods.Minimization
{
    public class GoldenRatio : SequentialStratetyMethod
    {
        private double l = default;

        public GoldenRatio(Interval interval, double l, SingleVarFunc functionHandler)
        {
            aArr.Add(interval.Begin);
            bArr.Add(interval.End);
            lArr.Add(bArr[k] - aArr[k]);
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
            yArr.Add(aArr[k] + (3 - Math.Sqrt(5)) / 2 * (bArr[k] - aArr[k]));
            zArr.Add(aArr[k] + bArr[k] - yArr[k]);
            return FourthStep();
        }

        private double FourthStep()
        {
            yResults.Add(functionHandler.Calculate(yArr[k]));
            zResults.Add(functionHandler.Calculate(zArr[k]));
            return FifthStep();
        }

        private double FifthStep()
        {
            if (yResults[k] <= zResults[k])
            {
                aArr.Add(aArr[k]);
                bArr.Add(zArr[k]);
                yArr.Add(aArr[k + 1] + bArr[k + 1] - yArr[k]);
                zArr.Add(yArr[k]);
            }
            else
            {
                aArr.Add(yArr[k]);
                bArr.Add(bArr[k]);
                yArr.Add(zArr[k]);
                zArr.Add(aArr[k + 1] + bArr[k + 1] - zArr[k]);
            }
            return SixthStep();
        }

        private double SixthStep()
        {
            var delta = Math.Abs(aArr[k + 1] - bArr[k + 1]);
            if (delta <= 1)
            {
                return (aArr[k + 1] + bArr[k + 1]) / 2;
            }
            else
            {
                k++;
                return FourthStep();
            }
        }
    }
}
