using Backend.Interfaces;
using System.Collections.Generic;

namespace Backend.Abstractions
{
    public abstract class SequentialStratetyMethod : IMethod
    {
        protected int k = default;
        protected List<double> aArr = new List<double>();
        protected List<double> bArr = new List<double>();
        protected List<double> lArr = new List<double>();
        protected List<double> yArr = new List<double>();
        protected List<double> zArr = new List<double>();
        protected List<double> yResults = new List<double>();
        protected List<double> zResults = new List<double>();
        protected FunctionHandler functionHandler = default;

        public abstract double Calculate();
    }
}