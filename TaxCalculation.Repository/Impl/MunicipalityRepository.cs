using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculation.Common.Entities;
using TaxCalculation.Common.Model;
using TaxCalculation.Repository.DBContext;
using TaxCalculation.Repository.Interfaces;

namespace TaxCalculation.Repository.Impl
{
    public class MunicipalityRepository : Repository<MunicipalityEntity>, IMunicipalityRepository
    {
        private readonly ApplicationDbContext _context;
        public MunicipalityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MunicipalityEntity> ValidateMunicipalityName(string name)
        {
            return await _context.municipalities.Where(x => x.MunicipalityName.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<bool> ValidateMunicipalityTaxRule(long municipalityId, long taxRuleId)
        {
            return await _context.municipalityRules.Where(x => x.MunicipalityId == municipalityId && x.TaxRuleId == taxRuleId).AnyAsync();
        }

        public async Task<List<TaxCalculationRange>> GetTaxRule(long taxRuleId)
        {
            return await (from muni in _context.municipalityTaxDetails
                          join finance in _context.financialYears
                          on muni.FinancialYearId equals finance.Id
                          join muniSche in _context.municipalitySchedules
                          on muni.MunicipalitySchedulesId equals muniSche.Id
                          where muni.TaxRuleId == taxRuleId && muni.Tax != null
                          select new TaxCalculationRange
                          {
                              Period = muniSche.Id,
                              RangeFrom = finance.RangeFrom,
                              RangeTo = finance.RangeTo,
                              Tax = muni.Tax.HasValue ? muni.Tax.Value : 0
                          }).OrderBy(x => x.Period).ToListAsync();
        }
    }
}
