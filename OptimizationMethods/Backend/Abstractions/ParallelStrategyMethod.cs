using Backend.Interfaces;

namespace Backend.Abstractions
{
    public abstract class ParallelStrategyMethod : IMethod
    {
        protected double beginInterval = default;
        protected double endInterval = default;
        protected int calculations = default;
        protected SingleVarFunc functionHandler = default;

        public abstract double Calculate();
    }
}