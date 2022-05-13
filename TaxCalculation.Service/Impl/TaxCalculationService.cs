using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TaxCalculation.Common.Constants;
using TaxCalculation.Common.Entities;
using TaxCalculation.Common.Model;
using TaxCalculation.Common.Result;
using TaxCalculation.Repository.Interfaces;
using TaxCalculation.Services.Interfaces;

namespace TaxCalculation.Services.Impl
{
    public class TaxCalculationService : ITaxCalculationService
    {
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly IRepository<TaxRulesEntity> _taxRepository;

        public TaxCalculationService(IMunicipalityRepository municipalityRepository, IRepository<TaxRulesEntity> taxRepository)
        {
            _municipalityRepository = municipalityRepository;
            _taxRepository = taxRepository;
        }

        public async Task<TaxCalculationResult> TaxCalculation(TaxCalculationRequest taxCalculationRequest)
        {
            try
            {
                var municipality = await _municipalityRepository.ValidateMunicipalityName(taxCalculationRequest.Municipality).ConfigureAwait(false);
                if (municipality != null)
                {
                    var taxRule = await _taxRepository.GetById(taxCalculationRequest.TaxRule).ConfigureAwait(false);
                    if (taxRule != null)
                    {
                        if (await _municipalityRepository.ValidateMunicipalityTaxRule(municipality.Id, taxRule.Id))
                        {
                            var muniTaxDetails = await _municipalityRepository.GetTaxRule(taxRule.Id);
                            if (taxRule.Id == (int)Constant.TaxRule.Rule1)
                            {
                                var result = await Rule1Calculation(muniTaxDetails, taxCalculationRequest.Date);
                                return new TaxCalculationResult { StatusCode = (int)HttpStatusCode.OK, Tax = result, ErrorMessages = null };
                            }
                            else if (taxRule.Id == (int)Constant.TaxRule.Rule2)
                            {
                                var result = await Rule2Calculation(muniTaxDetails, taxCalculationRequest.Date);
                                return new TaxCalculationResult { StatusCode = (int)HttpStatusCode.OK, Tax = result, ErrorMessages = null };
                            }
                        }
                        return new TaxCalculationResult { StatusCode = (int)HttpStatusCode.BadRequest, Tax = null, ErrorMessages = Constant.InvalidMunicipalityTaxRule };
                    }
                    return new TaxCalculationResult { StatusCode = (int)HttpStatusCode.BadRequest, Tax = null, ErrorMessages = Constant.InvalidTaxRule };
                }
                return new TaxCalculationResult { StatusCode = (int)HttpStatusCode.BadRequest, Tax = null, ErrorMessages = Constant.InvalidMunicipality };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<double> Rule1Calculation(List<TaxCalculationRange> taxCalculationRanges, DateTime date)
        {
            double tax = 0;

            foreach (var taxDetail in taxCalculationRanges)
            {
                if (date >= taxDetail.RangeFrom && (taxDetail.RangeTo == null || (taxDetail.RangeTo != null && date <= taxDetail.RangeTo)))
                {
                    tax += (taxDetail.Tax);
                }

            }
            return Math.Round(tax, 2);
        }

        private async Task<double> Rule2Calculation(List<TaxCalculationRange> taxCalculationRanges, DateTime date)
        {
            double tax = 0;
            foreach (var taxDetail in taxCalculationRanges)
            {
                if (date == taxDetail.RangeFrom && taxDetail.RangeTo == null)
                {
                    return tax = taxDetail.Tax;
                }

                if (date >= taxDetail.RangeFrom && (taxDetail.RangeTo != null && date <= taxDetail.RangeTo))
                {
                    return tax = taxDetail.Tax;
                }
            }

            return Math.Round(tax);
        }
    }
}
