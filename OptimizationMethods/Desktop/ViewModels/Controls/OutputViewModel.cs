using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels.Controls
{
    public class OutputViewModel
    {
        private Output Output { get; set; }

        public OutputViewModel(Output output)
        {
            this.Output = output;
        }

        public void PrintResult(double result)
        {
            Output.OutputBox.AppendText($"Результат вычисления: {result}\n");
        }
    }
}