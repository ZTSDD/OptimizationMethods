using Backend.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Methods.ZeroOrderMethods.Minimization
{
    public class Fibonacci : SequentialStratetyMethod
    {
        private int n = default;
        private double e = default;
        private double l = default;

        public Fibonacci(Interval interval, double e, double l, FunctionHandler functionHandler)
        {
            aArr.Add(interval.Begin);
            bArr.Add(interval.End);
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
            var value = (int)Math.Ceiling((bArr[k] - aArr[k]) / l);
            var n = 0;
            while (GetFibonacci(n) < value)
            {
                n++;
            }
            this.n = n;
            return ThirdStep();
        }

        private double ThirdStep()
        {
            k = 0;
            return FourthStep();
        }

        private double FourthStep()
        {
            yArr.Add(aArr[k] + GetFibonacci(n - 2) / GetFibonacci(n) * (bArr[k] - aArr[k]));
            zArr.Add(aArr[k] + GetFibonacci(n - 1) / GetFibonacci(n) * (bArr[k] - aArr[k]));
            return FifthStep();
        }

        private double FifthStep()
        {
            yResults.Add(functionHandler.Calculate(yArr[k]));
            zResults.Add(functionHandler.Calculate(zArr[k]));
            return SixthStep();
        }

        private double SixthStep()
        {
            if (yResults[k] <= zResults[k])
            {
                aArr.Add(aArr[k]);
                bArr.Add(zArr[k]);
                zArr.Add(yArr[k]);
                yArr.Add(aArr[k + 1] + GetFibonacci(n - k - 3) / GetFibonacci(n - k - 1) * (bArr[k + 1] - aArr[k + 1]));
            }
            else
            {
                aArr.Add(yArr[k]);
                bArr.Add(bArr[k]);
                yArr.Add(zArr[k]);
                zArr.Add(aArr[k + 1] + GetFibonacci(n - k - 2) / GetFibonacci(n - k - 1) * (bArr[k + 1] - aArr[k + 1]));
            }
            return SeventhStep();
        }

        private double SeventhStep()
        {
            if (!k.Equals(n - 3))
            {
                k++;
                return FifthStep();
            }
            else
            {
                yArr.Add((aArr[n - 2] + bArr[n - 2]) / 2);
                zArr.Add((aArr[n - 2] + bArr[n - 2]) / 2);
                yArr.Add(yArr[n - 2]);
                zArr.Add(yArr[n - 1] + e);
            }
            if (functionHandler.Calculate(yArr[n - 1]) <= functionHandler.Calculate(zArr[n - 1]))
            {
                aArr.Add(aArr[n - 2]);
                bArr.Add(zArr[n - 1]);
            }
            else
            {
                aArr.Add(yArr[n - 1]);
                bArr.Add(bArr[n - 2]);
            }
            return (aArr[n - 1] + bArr[n - 1]) / 2;
        }

        private double GetFibonacci(int n)
        {
            if (n < 0) throw new ArgumentException("Fibonacci indexes must be more than 0");
            if (n == 0) return 1;
            if (n == 1) return 1;
            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
            throw new Exception("Method not configured");
        }
    }
}
