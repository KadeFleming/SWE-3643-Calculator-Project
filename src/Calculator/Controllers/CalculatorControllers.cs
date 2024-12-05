using Microsoft.AspNetCore.Mvc;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpPost]
        public IActionResult Calculate(string operation, dynamic input)
        {
            try
            {
                switch (operation)
                {
                    case "mean":
                        return Json(Calculator.Models.CalculateMean(input));
                    case "sampleStdDev":
                        return Json(Calculator.Models.CalculateSampleStdDev(input));
                    case "populationStdDev":
                        return Json(Calculator.Models.CalculatePopulationStdDev(input));
                    case "zScore":
                        return Json(Calculator.Models.CalculateZScore(input.value, input.mean, input.stdDev));
                    case "linearRegression":
                        return Json(Calculator.Models.CalculateLinearRegression(input));
                    case "predictY":
                        return Json(Calculator.Models.PredictY(input.x, input.slope, input.intercept));
                    default:
                        return BadRequest("Invalid operation.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}