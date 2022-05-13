using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculation.Common.Entities
{
    [Table("taxrules")]
    public class TaxRulesEntity : BaseEntity
    {
        public TaxRulesEntity()
        {
            MunicipalityRule = new List<MunicipalityRuleEntity>();
            MunicipalityTaxDetails = new List<MunicipalityTaxDetailsEntity>();
        }
        [Column("rule")]
        public string Rule { get; set; }

        public virtual List<MunicipalityRuleEntity> MunicipalityRule { get; set; }
        public virtual List<MunicipalityTaxDetailsEntity> MunicipalityTaxDetails { get; set; }
    }
}
