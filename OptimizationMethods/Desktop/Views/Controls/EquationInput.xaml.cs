using Desktop.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Equation.xaml
    /// </summary>
    public partial class EquationInput : UserControl
    {
        public EquationInputViewModel ViewModel { get; set; }

        public EquationInput()
        {
            InitializeComponent();
            this.ViewModel = new EquationInputViewModel();
            this.DataContext = this.ViewModel;
        }
    }
}
