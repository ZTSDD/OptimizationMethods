using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Abstractions
{
    public abstract class TwoVarMethod
    {
        protected int k = default;
        protected double e = default;
        protected double e1 = default;
        protected double e2 = default;
        protected List<Pair> deltaFResults = new List<Pair>();
        protected List<Pair> xPairs = new List<Pair>();
        protected TwoVarsFunc functionHandler = default;
        protected int M = default;
        protected double tk = default;

        public abstract Pair Calculate();

        protected void AddXPair(int pos, Pair pair)
        {
            while (xPairs.Count - 1 < pos)
            {
                xPairs.Add(pair);
            }
            xPairs[pos] = pair;
        }

        protected void AddDeltaFResult(int pos, Pair pair)
        {
            while (deltaFResults.Count - 1 < pos)
            {
                deltaFResults.Add(pair);
            }
            deltaFResults[pos] = pair;
        }

        protected double Quadratic(Pair pair) => Math.Sqrt(
            Math.Pow(pair.x1, 2) + Math.Pow(pair.x2, 2));
    }
}
