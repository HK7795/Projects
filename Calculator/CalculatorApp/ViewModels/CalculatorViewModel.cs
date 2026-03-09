using CalculatorApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace CalculatorApp.ViewModels
{
    // The ViewModel for the CalculatorPage, responsible for handling all user interactions
    public partial class CalculatorPageViewModel : ObservableObject
    {
        // Calculator model that holds the state of the calculation
        private Calculator _calculator = new();

        // Property that holds the current number being displayed on the calculator
        [ObservableProperty]
        private string _numbersLabel = "0";

        // Property that holds the current equation being displayed on the calculator
        [ObservableProperty]
        private string _equationLabel = "";

        // Flag to determine if a new entry is being started (e.g., after pressing an operator or "C" button)
        private bool _isNewEntry = true;

        // Selects a number (digit) and updates the label on the screen
        public void SelectNumber(string digit)
        {
            // If it's a new entry or the number on the label is "0", replace it with the digit
            if (_isNewEntry || NumbersLabel == "0")
            {
                NumbersLabel = digit;
                _isNewEntry = false;
            }
            else
            {
                // Otherwise, append the digit to the current number
                NumbersLabel += digit;
            }
        }

        // Selects a mathematical operator and prepares for the next operation
        public void SelectMathOperator(string mathOperator)
        {
            // If there's an ongoing operation, calculate the result before proceeding
            if (!_isNewEntry)
            {
                Calculate();
            }

            // Set the operator and store the first number (the number displayed on the screen)
            _calculator.MathOperator = mathOperator;
            _calculator.FirstNumber = Convert.ToDouble(NumbersLabel);

            // Update the equation label to show the first number and operator
            EquationLabel = $"{_calculator.FirstNumber} {mathOperator}";
            _isNewEntry = true;
        }

        // Calculates the result of the current operation and updates the labels
        public void Calculate()
        {
            // If no operator is selected, return without doing anything
            if (string.IsNullOrEmpty(_calculator.MathOperator)) return;

            // Set the second number from the current value displayed on the screen
            _calculator.SecondNumber = Convert.ToDouble(NumbersLabel);

            // Perform the calculation using the MathUtil class and update the result
            _calculator.Result = MathUtil.Calculate(_calculator.FirstNumber, _calculator.SecondNumber, _calculator.MathOperator);

            // Update the equation label to show the full equation (e.g., "5 + 3 =")
            EquationLabel = $"{_calculator.FirstNumber} {_calculator.MathOperator} {_calculator.SecondNumber} =";

            // Display the result, or show "Error" if the result is NaN (e.g., division by zero)
            NumbersLabel = double.IsNaN(_calculator.Result) ? "Error" : _calculator.Result.ToString();

            // Store the result as the first number for the next operation
            _calculator.FirstNumber = _calculator.Result;
            _isNewEntry = true;
        }

        // Selects the percentage operation and updates the number label to show the percentage value
        public void SelectPercentage()
        {
            // Calculate the percentage by multiplying the number by 0.01
            NumbersLabel = (Convert.ToDouble(NumbersLabel) * 0.01).ToString();
        }

        // Clears the current entry (resets the numbers label to "0")
        public void ClearEntry()
        {
            NumbersLabel = "0";
            _isNewEntry = true;
        }

        // Clears all data (resets numbers, equation, and calculator state)
        public void Clear()
        {
            NumbersLabel = "0";
            EquationLabel = "";
            _calculator.FirstNumber = 0;
            _calculator.SecondNumber = 0;
            _calculator.MathOperator = "";
            _isNewEntry = true;
        }

        // Toggles the sign of the current number (positive to negative or vice versa)
        public void ToggleSign()
        {
            NumbersLabel = (Convert.ToDouble(NumbersLabel) * -1).ToString();
        }

        // Adds a decimal point to the current number, but only if it doesn't already have one
        public void AddDecimal()
        {
            // Check if the current number doesn't already have a decimal point
            if (!NumbersLabel.Contains("."))
            {
                NumbersLabel += "."; // Append a decimal point
            }
        }
    }
}
