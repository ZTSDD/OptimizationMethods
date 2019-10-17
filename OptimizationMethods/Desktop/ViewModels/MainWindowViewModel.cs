using Desktop.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Methods.ZeroOrderMethods.Minimization;
using Backend;
using Desktop.Models;
using System.Windows;

namespace Desktop.ViewModels
{
    class MainWindowViewModel
    {
        private MainWindow MainWindow { get; set; }

        public MainWindowViewModel(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
        }

        public void InitializeCalculations()
        {
            InputModel input = default;
            FunctionHandler functionHandler = default;
            Interval interval = default;
            IMethod method = default;
            try
            {
                input = new InputModel(MainWindow.OptionsInputControl.ViewModel);
            }
            catch
            {
                MessageBox.Show(
                    "Ввод параметров неверный, невозможно спарсить!",
                    "Ошибка ввода данных",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            try
            {
                functionHandler = new FunctionHandler(MainWindow.EquationInputControl.ViewModel.EquationInput);
            }
            catch
            {
                MessageBox.Show(
                    "Ввод уравнения неверный, невозможно спарсить!",
                    "Ошибка ввода уравнения",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            try
            {
                interval = new SwannAlg(functionHandler).FindInterval(input.X0, input.T);
                if (interval == null)
                    throw new ArgumentNullException();
            }
            catch
            {
                MessageBox.Show(
                    "Интервал не был найден!",
                    "Ошибка нахождения интервала",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            try
            {
                MainWindow.OxyPlotControl.ViewModel.Draw(functionHandler, interval.Begin, interval.End);
            }
            catch
            {
                MessageBox.Show("Не удолось нарисовать!",
                    "Ошибка отрисовки графика",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            try
            {
                method = GetMethod(interval, input, functionHandler);
            }
            catch
            {
                MessageBox.Show(
                    "Выбор метода неверный, невозможно спарсить!",
                    "Ошибка выбора метода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            double result = default;
            try
            {
                result = method.Calculate();
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка в вычислениях, невозможно закончить вычисление!",
                    "Ошибка вычисления",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            MainWindow.OutputControl.ViewModel.PrintResult(result);
        }

        private IMethod GetMethod(Interval interval, InputModel input, FunctionHandler functionHandler)
        {
            switch (input.SelectedMethod)
            {
                case MethodType.Bisection:
                    return new Bisection(interval, input.L, functionHandler);
                case MethodType.Dichotomy:
                    return new Dichotomy(interval, input.E, input.L, functionHandler);
                case MethodType.Fibonacci:
                    return new Fibonacci(interval, input.E, input.L, functionHandler);
                case MethodType.GoldenRatio:
                    return new GoldenRatio(interval, input.L, functionHandler);
                case MethodType.UniformSearch:
                    return new UniformSearch(interval.Begin, interval.End, input.C, functionHandler);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
