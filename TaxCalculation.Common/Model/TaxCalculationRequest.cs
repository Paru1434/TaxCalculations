using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace TaxCalculation.Common.Model
{
    public class TaxCalculationRequest
    {
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy.MM.dd")]
        public DateTime Date { get; set; }
        [Required]
        public int TaxRule { get; set; }
        [Required]
        public string Municipality { get; set; }

    }
}
