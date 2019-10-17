using Desktop.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для OptionsInput.xaml
    /// </summary>
    public partial class OptionsInput : UserControl
    {
        public OptionsInputViewModel ViewModel { get; set; }

        public OptionsInput()
        {
            InitializeComponent();
            this.MethodSelector.ItemsSource = Enum.GetValues(typeof(MethodType));
            this.DataContext = new OptionsInputViewModel(this);
            ViewModel = this.DataContext as OptionsInputViewModel;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}