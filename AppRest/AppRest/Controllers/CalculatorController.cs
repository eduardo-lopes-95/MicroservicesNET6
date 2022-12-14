using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AppRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var op = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(op.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var op = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(op.ToString());
            }
            return BadRequest("Invalid Input");
        }
        
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var op = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(op.ToString());
            }
            return BadRequest("Invalid Input");
        }
        
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && (NotZero(firstNumber)) && IsNumeric(secondNumber))
            {
                var op = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(op.ToString());
            }
            return BadRequest("Invalid Input");
        }
        
        [HttpGet("square/{firstNumber}")]
        public IActionResult Sqrt(string firstNumber)
        {
            if(IsNumeric(firstNumber))
            {
                var converted = (double) ConvertToDecimal(firstNumber);
                var op = Math.Sqrt(converted);
                return Ok(op.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool NotZero(string firstNumber)
        {
            var converted = ConvertToDecimal(firstNumber);
            if (converted != 0) return true;
            return false;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

    }
}
