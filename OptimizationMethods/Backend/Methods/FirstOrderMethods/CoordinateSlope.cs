using Backend.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Methods.FirstOrderMethods
{
    class CoordinateSlope : TwoVarMethod
    {
        int j;
        int n;
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
            j = 0;
            return ThirdStep();
            throw new NotImplementedException();
        }

        private Pair ThirdStep()
        {
            if (j >= M)
            {
                return xPairs[j * k];
            }
            else
            {
                return FourthStep();
            }
            return FourthStep();
            throw new NotImplementedException();
        }

        private Pair FourthStep()
        {
            k = 0;
            return FifthStep();
            throw new NotImplementedException();
        }

        private Pair FifthStep()
        {
            if (k <= n - 1)
            {
                return SixthStep();
            }
            if (k == n)
            {
                j++;

            }
            throw new NotImplementedException();
        }

        private Pair SixthStep()
        {
            throw new NotImplementedException();
        }
    }
}
