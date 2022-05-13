using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculation.Common.Entities
{
    [Table("municipalityschedules")]
    public class MunicipalitySchedulesEntity : BaseEntity
    {
        public MunicipalitySchedulesEntity()
        {
            MunicipalityTaxDetails = new List<MunicipalityTaxDetailsEntity>();
        }
        [Column("period")]
        public string Period { get; set; }
        public virtual List<MunicipalityTaxDetailsEntity> MunicipalityTaxDetails { get; set; }

    }
}
