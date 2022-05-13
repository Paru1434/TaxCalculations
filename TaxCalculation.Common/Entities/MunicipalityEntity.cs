using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculation.Common.Entities
{
    [Table("municipality")]
    public class MunicipalityEntity : BaseEntity
    {
        public MunicipalityEntity()
        {
            MunicipalityRule = new List<MunicipalityRuleEntity>();
        }
        [Column("municipalityname")]
        public string MunicipalityName { get; set; }

        public virtual List<MunicipalityRuleEntity> MunicipalityRule { get; set; }
    }

}
