
namespace CalculatorApp.Models
    {
        public static class MathUtil
        {
            // This method calculates the result based on the operator passed.
            // It takes in two numbers and the operator as a string, and returns the result of the operation.
            public static double Calculate(double firstNumber, double secondNumber, string mathOperator)
            {
                // Switch statement to select the operation based on the mathOperator string
                switch (mathOperator)
                {
                    // Addition: Add firstNumber and secondNumber
                    case "+":
                        return firstNumber + secondNumber;

                    // Subtraction: Subtract secondNumber from firstNumber
                    case "-":
                        return firstNumber - secondNumber;

                    // Multiplication: Multiply firstNumber by secondNumber
                    case "×":
                        return firstNumber * secondNumber;

                    // Division: Divide firstNumber by secondNumber. If secondNumber is 0, return NaN
                    case "÷":
                        // Check for division by zero to avoid errors and undefined result
                        if (secondNumber == 0)
                        {
                            return double.NaN; // Return NaN to indicate undefined result
                        }
                        return firstNumber / secondNumber;

                    // Percentage: Calculate the percentage of firstNumber (i.e., firstNumber * 0.01)
                    case "%":
                        return firstNumber * 0.01;

                    // Default case: If the operator is not recognized, return 0
                    default:
                        return 0; // Return 0 for unsupported operators
                }
            }
        }
    }

                

