using System;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculation.Common.Model
{
    public class TaxCalculationRange
    {
        public DateTime RangeFrom { get; set; }
        public DateTime? RangeTo { get; set; }
        public double Tax { get; set; }
        public long Period { get; set; }
    }
}
