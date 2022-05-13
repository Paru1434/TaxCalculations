using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TaxCalculation.Common.Model;
using TaxCalculation.Services.Interfaces;

namespace TaxCalculation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculationController : ControllerBase
    {
        private readonly ITaxCalculationService _taxCalculationService;

        public TaxCalculationController(ITaxCalculationService taxCalculationService)
        {
            _taxCalculationService = taxCalculationService;
        }

        [HttpGet]
        [Route("taxdetails")]
        [Produces("application/json")]
        public async Task<ActionResult> Get([FromQuery] TaxCalculationRequest taxCalculation)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(await _taxCalculationService.TaxCalculation(taxCalculation));

                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
