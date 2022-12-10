using System.ComponentModel.DataAnnotations;

namespace Calculator.Web.Models;

public class CalculatorViewModel
{
    public decimal? FirstOperand { get; set; }
    public decimal? SecondOperand { get; set; }
    public decimal? Result { get; set; }
}
