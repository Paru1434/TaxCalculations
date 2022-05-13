using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculation.Common.Model;
using TaxCalculation.Common.Result;

namespace TaxCalculation.Services.Interfaces
{
    public interface ITaxCalculationService
    {
        Task<TaxCalculationResult> TaxCalculation(TaxCalculationRequest taxCalculationRequest);
    }
}
