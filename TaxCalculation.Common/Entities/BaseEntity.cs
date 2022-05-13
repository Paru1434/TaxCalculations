using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculation.Common.Entities
{
    public class BaseEntity
    {
        // [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("createdat", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("createdby")]
        public string CreatedBy { get; set; }

        [Column("updatedat", TypeName = "timestamp")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("updatedby")]
        public string UpdatedBy { get; set; }
    }
}
