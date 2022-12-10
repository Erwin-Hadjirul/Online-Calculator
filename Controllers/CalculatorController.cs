using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Calculator.Web.Models;

namespace Calculator.Web.Controllers;

public class CalculatorController : Controller
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(CalculatorViewModel calculator, string command)
    {
        decimal result = default;
        CalculatorViewModel newVariable = new CalculatorViewModel
        {
            FirstOperand = 0,
            SecondOperand = 0,
            Result = 0
        };
        CalculatorViewModel output = newVariable;

        switch (command)
        {
            case "C":
                break;
            default:
                result = command switch
                {
                    "+" => calculator.Result = calculator.FirstOperand + calculator.SecondOperand,
                    "-" => calculator.Result = calculator.FirstOperand - calculator.SecondOperand,
                    "x" => calculator.Result = calculator.FirstOperand * calculator.SecondOperand,
                    "÷" => calculator.Result = calculator.FirstOperand / calculator.SecondOperand,
                    _ => 0
                } ?? 0;
                output = new CalculatorViewModel { Result = result };
                break;
        }

        return View(output);
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
