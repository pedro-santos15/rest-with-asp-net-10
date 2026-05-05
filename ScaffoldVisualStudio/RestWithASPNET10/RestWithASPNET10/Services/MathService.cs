using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Utils;

namespace RestWithASPNET10.Services
{
    public class MathService
    {

        private readonly NumberValidator _validator;

        public MathService (NumberValidator validator)
        {
            _validator = validator;
        }

        public decimal? Sum(string firstNumber, string secondNumber)
        {
            if (_validator.IsNumeric(firstNumber) && _validator.IsNumeric(secondNumber))
            {
                decimal sum = decimal.Parse(firstNumber) + decimal.Parse(secondNumber);
                return sum;
            }
            return null;
        }

        public decimal? Multiplication(string firstNumber, string secondNumber)
        {
            if (_validator.IsNumeric(firstNumber) && _validator.IsNumeric(secondNumber))
            {
                var result = decimal.Parse(firstNumber) * decimal.Parse(secondNumber);
                return result;
            }
            return null;
        }

        public decimal? Subtraction(string firstNumber, string secondNumber)
        {
            if (_validator.IsNumeric(firstNumber) && _validator.IsNumeric(secondNumber))
            {
                var result = decimal.Parse(firstNumber) - decimal.Parse(secondNumber);
                return result;
            }
            return null;
        }

        public decimal? Division(string firstNumber, string secondNumber)
        {
            if (_validator.IsNumeric(firstNumber) && _validator.IsNumeric(secondNumber))
            {
                var result = decimal.Parse(firstNumber) / decimal.Parse(secondNumber);
                return result;
            }
            return null;
        }

        public decimal? Average(string firstNumber, string secondNumber)
        {
            if (_validator.IsNumeric(firstNumber) && _validator.IsNumeric(secondNumber))
            {
                var sum = decimal.Parse(firstNumber) + decimal.Parse(secondNumber);
                var average = sum / 2;
                return average;
            }
            return null;
        }

        public double? Sqrt(string firstNumber, string secondNumber)
        {
            if (_validator.IsNumeric(firstNumber) && _validator.IsNumeric(secondNumber))
            {
                var sum = double.Parse(firstNumber) + double.Parse(secondNumber);
                var sqrt = Math.Sqrt(sum);
                return sqrt;
            }
            return null;
        }

    }
}
