using org.mariuszgromada.math.mxparser;

namespace Backend
{
    public class FunctionHandler
    {
        private Function function;
        private string funcHead = "F(x)";
        public FunctionHandler(string functionPart)
        {
            this.function = new Function($"F(x) = {functionPart}");
        }

        public double Calculate(double x)
        {
            var arg = new Argument($"x = {x.ToString().Replace(",", ".")}");
            var ex = new Expression(funcHead, function, arg);
            return ex.calculate();
        }
    }
}