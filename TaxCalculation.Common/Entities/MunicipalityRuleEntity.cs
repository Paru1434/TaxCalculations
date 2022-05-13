using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculation.Common.Entities
{
    [Table("municipalityrule")]
    public class MunicipalityRuleEntity : BaseEntity
    {
        public MunicipalityRuleEntity()
        {
            //Municipality = new List<MunicipalityEntity>();
            //TaxRuleId = new List<TaxRulesEntity>();
            Municipality = new MunicipalityEntity();
            TaxRule = new TaxRulesEntity();
        }
        [Column("municipalityid")]
        [ForeignKey("municipalityid")]
        public long MunicipalityId { get; set; }

        [Column("taxruleid")]
        [ForeignKey("taxruleid")]
        public long TaxRuleId { get; set; }
        public virtual MunicipalityEntity Municipality { get; set; }
        public virtual TaxRulesEntity TaxRule { get; set; }
        //public virtual List<MunicipalityEntity> Municipality { get; set; }
        //public virtual List<TaxRulesEntity> TaxRuleId { get; set; }
    }
}
