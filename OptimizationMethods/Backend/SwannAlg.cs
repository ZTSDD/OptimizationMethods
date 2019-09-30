using System;
using System.Collections.Generic;

namespace Backend
{
    class SwannAlg
    {
        private FunctionHandler functionHandler;
        private enum SwannState
        {
            IntervalFound,
            IntervalNotExist,
            Continue
        }
        public SwannAlg(FunctionHandler functionHandler)
        {
            this.functionHandler = functionHandler;
        }

        public Interval FindInterval(double x0, double t)
        {
            var results = PerformSecondStep(x0, t);
            switch (PerformThirdStep(results))
            {
                case SwannState.IntervalFound:
                    return new Interval(results[0], results[2]);
                case SwannState.IntervalNotExist:
                    return null;
                default:
                    return GuarantedFinding(results, x0, t);
            }
        }

        private List<double> PerformSecondStep(double x0, double t)
        {
            return new List<double>()
            {
                functionHandler.Calculate(x0 - t),
                functionHandler.Calculate(x0),
                functionHandler.Calculate(x0 = t)
            };
        }

        private SwannState PerformThirdStep(List<double> funcResults)
        {
            if ((funcResults[0] >= funcResults[1]) && (funcResults[1] <= funcResults[2]))
            {
                return SwannState.IntervalFound;
            }
            if ((funcResults[0] <= funcResults[1]) && (funcResults[1] >= funcResults[2]))
            {
                return SwannState.IntervalNotExist;
            }
            return SwannState.Continue;
        }

        private Interval GuarantedFinding(List<double> results, double x0, double t)
        {
            var xArr = new List<double>() { x0 };
            double delta = 0;
            double a0 = default;
            double b0 = default;
            int k = 0;
            PerformFourthStep(ref a0, ref b0, ref k, ref delta, ref t, ref xArr, ref results);
            do
            {
                // The fifth step.
                xArr[k + 1] = xArr[k] + Math.Pow(2, k) * delta;
                results = new List<double>()
                {
                    functionHandler.Calculate(xArr[k+1]),
                    functionHandler.Calculate(xArr[k])
                };
                if ((results[0] < results[1]) && delta == t)
                {
                    a0 = xArr[k++];
                    // repeat the fifth step and perform the sixth one by a.
                    continue;
                }
                if ((results[0] < results[1]) && delta == -t)
                {
                    b0 = xArr[k++];
                    // repeat the fifth step and perform the sixth one by a.
                    continue;
                }
                // Otherwise the sixth step by b will performing below.
                if (delta.Equals(t))
                    b0 = xArr[k + 1];
                else
                    a0 = xArr[k + 1];
                // The interval found. Go out from the cycle.
            } while (false);
            return new Interval(a0, b0);
        }

        private void PerformFourthStep(ref double a0, ref double b0, ref int k,
            ref double delta, ref double t, ref List<double> xArr, ref List<double> initResults)
        {
            if ((initResults[0] >= initResults[1]) && (initResults[1] >= initResults[2]))
            {
                delta = t;
                a0 = xArr[0];
                xArr[1] = xArr[0] + t;
                k++;
            }
            if ((initResults[0] <= initResults[1]) && (initResults[1] <= initResults[2]))
            {
                delta = -t;
                b0 = xArr[0];
                xArr[1] = xArr[0] - t;
                k++;
            }
        }
    }
}