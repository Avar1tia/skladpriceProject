using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace SkladPrice.Pages
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public sealed partial class Calculator : Page, INotifyPropertyChanged
    {
        private string _result = "0";
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        public ICommand NumberButtonCommand { get; private set; }
        public ICommand OperatorButtonCommand { get; private set; }
        public ICommand EqualsButtonCommand { get; private set; }
        public ICommand ClearButtonCommand { get; private set; }
        public Calculator()
        {
            this.InitializeComponent();
            this.DataContext = this;

            NumberButtonCommand = new RelayCommand<string>(AppendToResult);
            OperatorButtonCommand = new RelayCommand<string>(SetOperator);
            EqualsButtonCommand = new RelayCommand<object>(CalculateResult);
            ClearButtonCommand = new RelayCommand<object>(ClearResult);
        }
        private void AppendToResult(string value)
        {
            if (Result == "0" || Result == "Error")
                Result = value;
            else
                Result += value;
        }
        private void SetOperator(string op)
        {
            Result += " " + op + " ";
        }
        private void CalculateResult(object parameter)
        {
            try
            {
                Result = Evaluate(Result).ToString();
            }
            catch (Exception)
            {
                Result = "Error";
            }
        }
        private void ClearResult(object parameter)
        {
            Result = "0";
        }
        private double Evaluate(string expression)
        {
            var dataTable = new System.Data.DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        public event EventHandler CanExecuteChanged;
    }
}