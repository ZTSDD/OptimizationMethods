using System;

namespace Backend
{
    public class Interval
    {
        public double Begin { get; private set; }
        public double End { get; private set; }

        public Interval(double begin, double end)
        {
            if (begin > end)
                throw new ArgumentException("The interval is not set correctly");
            Begin = begin;
            End = end;
        }

        public void SetBegin(double begin)
        {
            if (begin > End)
                throw new ArgumentException("begin > end");
            Begin = begin;
        }

        public void SetEnd(double end)
        {
            if (end < Begin)
                throw new ArgumentException("end < begin");
            End = end;
        }
    }
}