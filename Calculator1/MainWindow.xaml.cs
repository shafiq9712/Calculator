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

namespace Calculator1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            resultLabel.Content = "";

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalstoButton.Click += EqualstoButton_Click;
       

        }

        private void EqualstoButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            int size = resultLabel.Content.ToString().Length;
            resultLabel.Content = resultLabel.Content.ToString().Remove(0, size - 1);
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtaction:
                        result = SimpleMath.Sub(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * (-1);
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }
       
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                selectedOperator = SelectedOperator.Subtaction;
            if (sender == starButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {

                if (selectedOperator == SelectedOperator.Addition)
                    resultLabel.Content = $"{resultLabel.Content}+";

                else if (selectedOperator == SelectedOperator.Subtaction)
                    resultLabel.Content = $"{resultLabel.Content}-";

                else if (selectedOperator == SelectedOperator.Multiplication)
                    resultLabel.Content = $"{resultLabel.Content}x";

                else
                    resultLabel.Content = $"{resultLabel.Content}÷";
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
                resultLabel.Content = $"{resultLabel.Content}.";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = $"{selectedValue}";

            else
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtaction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }

    }
}