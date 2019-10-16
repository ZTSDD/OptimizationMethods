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
        public Interval Interval { get; set; }
        public double E { get; set; }
        public double L { get; set; }
        public int C { get; set; }
        public MethodType SelectedMethod { get; set; }

        public InputModel(OptionsInputViewModel model)
        {
            this.C = int.Parse(model.CInput);
            this.E = double.Parse(model.EInput);
            this.L = double.Parse(model.LInput);
            this.SelectedMethod = (MethodType)Enum.Parse(typeof(MethodType), model.SelectedMethod);
            this.Interval = new Interval(double.Parse(model.BegInput), double.Parse(model.EndInput));
        }
    }
}
