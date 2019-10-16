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
    /// Логика взаимодействия для Output.xaml
    /// </summary>
    public partial class Output : UserControl
    {
        public OutputViewModel ViewModel { get; set; }
        public Output()
        {
            InitializeComponent();
            this.DataContext = new OutputViewModel(this);
            ViewModel = this.DataContext as OutputViewModel;
        }
    }
}
