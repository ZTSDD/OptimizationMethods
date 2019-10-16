using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.ViewModels.Controls
{
    public class OptionsInputViewModel
    {
        private OptionsInput OptionsInput { get; set; }
        public string BegInput { get; set; }
        public string EndInput { get; set; }
        public string EInput { get; set; }
        public string LInput { get; set; }
        public string CInput { get; set; }
        private string _selectedMethod;
        public string SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                this._selectedMethod = value;
                switch ((MethodType)Enum.Parse(typeof(MethodType), value))
                {
                    case MethodType.Bisection:
                        {
                            OptionsInput.CInputBox.Visibility = Visibility.Collapsed;
                            OptionsInput.LInputBox.Visibility = Visibility.Visible;
                            OptionsInput.EInputBox.Visibility = Visibility.Collapsed;
                        }
                        break;
                    case MethodType.Dichotomy:
                        {
                            OptionsInput.CInputBox.Visibility = Visibility.Collapsed;
                            OptionsInput.LInputBox.Visibility = Visibility.Visible;
                            OptionsInput.EInputBox.Visibility = Visibility.Visible;
                        }
                        break;
                    case MethodType.Fibonacci:
                        {
                            OptionsInput.CInputBox.Visibility = Visibility.Collapsed;
                            OptionsInput.LInputBox.Visibility = Visibility.Visible;
                            OptionsInput.EInputBox.Visibility = Visibility.Visible;
                        }
                        break;
                    case MethodType.GoldenRatio:
                        {
                            OptionsInput.CInputBox.Visibility = Visibility.Collapsed;
                            OptionsInput.LInputBox.Visibility = Visibility.Visible;
                            OptionsInput.EInputBox.Visibility = Visibility.Collapsed;
                        }
                        break;
                    case MethodType.UniformSearch:
                        {
                            OptionsInput.CInputBox.Visibility = Visibility.Visible;
                            OptionsInput.LInputBox.Visibility = Visibility.Collapsed;
                            OptionsInput.EInputBox.Visibility = Visibility.Collapsed;
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        public ObservableCollection<string> MethodTypes { get; private set; }

        public OptionsInputViewModel(OptionsInput optionsInput)
        {
            this.OptionsInput = optionsInput;
            this.MethodTypes = new ObservableCollection<string>(Enum.GetNames(typeof(MethodType)).ToList());
        }
    }
}