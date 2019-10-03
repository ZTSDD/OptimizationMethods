using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;

namespace Desktop.Models
{
    class EquationOptions
    {
        FunctionHandler functionHandler;
        private Dictionary<string, double> options;
        MethodType methodType;

        public EquationOptions(
            FunctionHandler functionHandler, 
            Dictionary<string, double> options)
        {
            this.functionHandler = functionHandler ??
                throw new ArgumentNullException(nameof(functionHandler));
            this.options = options ??
                throw new ArgumentNullException(nameof(options));
        }
    }
}