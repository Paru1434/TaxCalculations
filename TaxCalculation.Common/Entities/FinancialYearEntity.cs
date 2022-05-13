using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculation.Common.Entities
{

    [Table("financialyear")]
    public class FinancialYearEntity : BaseEntity
    {
        public FinancialYearEntity()
        {
            MunicipalityTaxDetails = new List<MunicipalityTaxDetailsEntity>();
        }
        [Column("rangefrom", TypeName = "date")]
        public DateTime RangeFrom { get; set; }

        [Column("rangeto", TypeName = "date")]
        public DateTime? RangeTo { get; set; }
        public virtual List<MunicipalityTaxDetailsEntity> MunicipalityTaxDetails { get; set; }


    }
}
