using Backend;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels.Controls
{

    public class OxyPlotViewModel
    {
        public PlotModel MyModel { get; private set; }
        public OxyPlotViewModel()
        {
            this.MyModel = new PlotModel { Title = "Func" };
        }
        public void Draw(FunctionHandler functionHandler, double x0, double x1)
        {
            this.MyModel.Series.Add(new FunctionSeries(functionHandler.Calculate, x0, x1, 0.1, "Current func"));
            this.MyModel.InvalidatePlot(true);
        }
    }
}
