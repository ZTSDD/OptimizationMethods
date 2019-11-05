using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public class TwoVarsFunc
    {
        private Function function;
        private string funcPart;
        private string funcHead = "F(x1, x2)";
        public TwoVarsFunc(string functionPart)
        {
            this.funcPart = functionPart;
            this.function = new Function($"F(x1, x2) = {functionPart}");
            if (!function.checkSyntax())
                throw new ArgumentException();
        }

        public double CalculateX1Grad(double x1, double x2)
        {
            var x1Arg = new Argument($"x1 = {x1.ToString().Replace(",", ".")}");
            var x2Arg = new Argument($"x2 = {x2.ToString().Replace(",", ".")}");
            var x1Der = new Expression($"der({funcPart}, x1)", x1Arg, x2Arg);
            return x1Der.calculate();
        }

        public double CalculateX2Grad(double x1, double x2)
        {
            var x1Arg = new Argument($"x1 = {x1.ToString().Replace(",", ".")}");
            var x2Arg = new Argument($"x2 = {x2.ToString().Replace(",", ".")}");
            var x2Der = new Expression($"der({funcPart}, x2)", x1Arg, x2Arg);
            return x2Der.calculate();
        }

        public double Calculate(double x1, double x2)
        {
            var x1Arg = new Argument($"x1 = {x1.ToString().Replace(",", ".")}");
            var x2Arg = new Argument($"x2 = {x2.ToString().Replace(",", ".")}");
            var ex = new Expression(funcHead, function, x1Arg, x2Arg);
            return ex.calculate();
        }
    }
}