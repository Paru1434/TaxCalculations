using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculation.Common.Entities;
using TaxCalculation.Common.Model;

namespace TaxCalculation.Repository.Interfaces
{
    public interface IMunicipalityRepository : IRepository<MunicipalityEntity>
    {
        Task<MunicipalityEntity> ValidateMunicipalityName(string name);
        Task<bool> ValidateMunicipalityTaxRule(long municipalityId, long taxRuleId);
        Task<List<TaxCalculationRange>> GetTaxRule(long taxRuleId);
    }
}
