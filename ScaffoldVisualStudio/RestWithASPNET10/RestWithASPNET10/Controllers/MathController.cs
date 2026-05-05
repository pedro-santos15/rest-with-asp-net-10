using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly MathService _service;

        public MathController(MathService service)
        {
            _service = service;
        }


        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            var sum = _service.Sum(firstNumber, secondNumber);
            if (sum != null)
            {
                return Ok(sum);
            }

            return BadRequest("Invalid Input!");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplication(string firstNumber, string secondNumber)
        {
            var result = _service.Multiplication(firstNumber,secondNumber);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Invalid Input!");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtraction(string firstNumber, string secondNumber)
        {
            var result = _service.Subtraction(firstNumber, secondNumber);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Invalid Input!");
        }
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivision(string firstNumber, string secondNumber)
        {
            try
            {
                var result = _service.Division(firstNumber, secondNumber);
                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest("Invalid Input!");
            }
            catch (DivideByZeroException e)
            {
                return BadRequest(e.Message);
            }
 
        }
        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult GetAverage(string firstNumber, string secondNumber)
        {
            var result = _service.Average(firstNumber, secondNumber);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Invalid Input!");
        }

        [HttpGet("sqrt/{firstNumber}/{secondNumber}")]
        public IActionResult GetSqrt(string firstNumber, string secondNumber)
        {
            var result = _service.Sqrt(firstNumber, secondNumber);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Invalid Input!");
        }
    }
}
