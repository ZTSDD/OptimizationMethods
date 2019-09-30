using Backend.Abstractions;

namespace Backend.Methods.ZeroOrderMethods.Minimization
{
    public class UniformSearch : ParallelStrategyMethod
    {
        public UniformSearch(double beg, double end, int calculations, FunctionHandler functionHandler)
        {
            beginInterval = beg;
            endInterval = end;
            this.calculations = calculations;
            this.functionHandler = functionHandler;
        }

        public override double Calculate()
        {
            var xResults = new double[calculations];
            var xPositions = new double[calculations];
            for (int i = 0; i < calculations; i++)
            {
                // Get all positions of the x with the constant step.
                xPositions[i] = beginInterval + i * (endInterval - beginInterval) / (calculations + 1);
                // Calculate the function for each x.
                xResults[i] = functionHandler.Calculate(xPositions[i]);
            }
            // Find minimum index.
            var minIndex = 0;
            for (int i = 1; i < calculations; i++)
            {
                if (xResults[i] < xResults[minIndex])
                {
                    minIndex = i;
                }
            }
            // Return x with minimum function value.
            return xPositions[minIndex];
        }
    }
}