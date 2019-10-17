using Backend;
using Desktop.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    class InputModel
    {
        public double X0 { get; set; }
        public double T { get; set; }
        public double E { get; set; }
        public double L { get; set; }
        public int C { get; set; }
        public MethodType SelectedMethod { get; set; }

        public InputModel(OptionsInputViewModel model)
        {
            this.C = int.Parse(model?.CInput?.Replace(".", ",") ?? "0");
            this.E = double.Parse(model?.EInput?.Replace(".", ",") ?? "0");
            this.L = double.Parse(model?.LInput?.Replace(".", ",") ?? "0");
            this.X0 = double.Parse(model?.X0Input?.Replace(".", ",") ?? "0");
            this.T = double.Parse(model?.TInput?.Replace(".", ",") ?? "0");
            this.SelectedMethod = (MethodType)Enum.Parse(typeof(MethodType), model.SelectedMethod);
        }
    }
}
