using CalculatorApp.ViewModels;
using Microsoft.Maui.Controls;

namespace CalculatorApp.Views
{
    public partial class CalculatorPage : ContentPage
    {
        // ViewModel for managing the logic of the calculator
        private CalculatorPageViewModel _viewModel;

        public CalculatorPage()
        {
            InitializeComponent();
            _viewModel = new CalculatorPageViewModel();
            BindingContext = _viewModel; // Set the BindingContext to the ViewModel
        }

        // Handles the click event for number buttons
        private void NumClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                _viewModel.SelectNumber(button.Text); // Pass the number to ViewModel
            }
        }

        // Handles the click event for operator buttons
        private void OpClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                _viewModel.SelectMathOperator(button.Text); // Pass the operator to ViewModel
            }
        }

        // Handles the equal button click to perform the calculation
        private void EqualClick(object sender, EventArgs e)
        {
            _viewModel.Calculate(); // Trigger calculation in ViewModel
        }

        // Clears the current entry (not the entire calculation)
        private void CEClick(object sender, EventArgs e)
        {
            _viewModel.ClearEntry(); // Clear the current input
        }

        // Clears the entire calculation, resetting everything
        private void CClick(object sender, EventArgs e)
        {
            _viewModel.Clear(); // Reset the calculator
        }

        // Toggles the sign (positive/negative) of the current number
        private void SignClick(object sender, EventArgs e)
        {
            _viewModel.ToggleSign(); // Change the sign in ViewModel
        }

        // Adds a decimal point if not already present
        private void DotClick(object sender, EventArgs e)
        {
            _viewModel.AddDecimal(); // Add a decimal point in ViewModel
        }
    }
}
