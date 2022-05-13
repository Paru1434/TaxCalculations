using System.Collections.Generic;
using System.Net;

namespace TaxCalculation.Common.Result
{
    public class TaxCalculationResult
    {
        public double? Tax { get; set; }
        public string ErrorMessages { get; set; }
        public int StatusCode { get; set; }
    }
}
