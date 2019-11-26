using Backend.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Methods.SecondOrderMethods
{
    class NewtoneMethod : TwoVarMethod
    {
        public override Pair Calculate()
        {
            throw new NotImplementedException();
        }

        public Pair FistStep()
        {
            // TODO CHECKING
            return SecondStep();
        }

        private Pair SecondStep()
        {
            k = 0;
            return ThirdStep();
        }

        private Pair ThirdStep()
        {
            AddDeltaFResult(k, new Pair { 
                x1 = functionHandler.CalculateX1Grad(xPairs[k].x1, xPairs[k].x2), 
                x2 = functionHandler.CalculateX2Grad(xPairs[k].x1, xPairs[k].x2) });
            return FourthStep();
        }

        private Pair FourthStep()
        {
            if (Math.Abs(Quadratic(deltaFResults[k])) <= e1)
            {
                return xPairs[k];
            }
            else
            {
                return FifthStep();
            }
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
        }

        private Pair SixthStep()
        {

            throw new NotImplementedException();
        }
    }
}
