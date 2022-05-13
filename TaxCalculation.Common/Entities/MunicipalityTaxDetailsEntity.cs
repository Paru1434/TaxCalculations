using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculation.Common.Entities
{
    [Table("municipalitytaxdetails")]
    public class MunicipalityTaxDetailsEntity : BaseEntity
    {
        public MunicipalityTaxDetailsEntity()
        {
            MunicipalitySchedules = new MunicipalitySchedulesEntity();
            TaxRule = new TaxRulesEntity();
            FinancialYear = new FinancialYearEntity();
        }

        [Column("tax", TypeName = "decimal")]
        public double? Tax { get; set; }

        [Column("municipalityschedulesid")]
        [ForeignKey("municipalityschedulesid")]
        public long MunicipalitySchedulesId { get; set; }

        [Column("taxruleid")]
        [ForeignKey("taxruleid")]
        public long TaxRuleId { get; set; }

        [Column("financialyearid")]
        [ForeignKey("financialyearid")]
        public long? FinancialYearId { get; set; }

        public virtual MunicipalitySchedulesEntity MunicipalitySchedules { get; set; }
        public virtual TaxRulesEntity TaxRule { get; set; }
        public virtual FinancialYearEntity FinancialYear { get; set; }
    }
}
