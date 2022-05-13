using TaxCalculation.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TaxCalculation.Repository.DBContext
{
    public partial class ApplicationDbContext : DbContext
    {
        private ModelBuilder modelBuilder;

        public DbSet<MunicipalityTaxDetailsEntity> municipalityTaxDetails { get; set; }
        public DbSet<TaxRulesEntity> taxRules { get; set; }
        public DbSet<FinancialYearEntity> financialYears { get; set; }
        public DbSet<MunicipalityEntity> municipalities { get; set; }
        public DbSet<MunicipalityRuleEntity> municipalityRules { get; set; }
        public DbSet<MunicipalitySchedulesEntity> municipalitySchedules { get; set; }

        ////  comment when uncommenting OnConfiguring and ApplicationDbContext method
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Local development to generating the migrations- OnConfiguring and ApplicationDbContext
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString =
        //        $"Host=localhost;port=5432;Database=taxcaluclation;Username=admin;Password=admin;Persist Security Info=true;Pooling=true;";
        //    optionsBuilder.UseNpgsql(connectionString);
        //}
        //public ApplicationDbContext()
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;

            this.modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MunicipalityEntity>()
                .HasMany<MunicipalityRuleEntity>(g => g.MunicipalityRule)
                .WithOne(s => s.Municipality)
                .HasForeignKey(s => s.MunicipalityId)
                .IsRequired();
            modelBuilder.Entity<TaxRulesEntity>()
                .HasMany<MunicipalityRuleEntity>(g => g.MunicipalityRule)
                .WithOne(s => s.TaxRule)
                .HasForeignKey(s => s.TaxRuleId)
                .IsRequired();
            modelBuilder.Entity<TaxRulesEntity>()
                .HasMany<MunicipalityTaxDetailsEntity>(g => g.MunicipalityTaxDetails)
                .WithOne(s => s.TaxRule)
                .HasForeignKey(s => s.TaxRuleId)
                .IsRequired();
            modelBuilder.Entity<FinancialYearEntity>()
                .HasMany<MunicipalityTaxDetailsEntity>(g => g.MunicipalityTaxDetails)
                .WithOne(s => s.FinancialYear)
                .HasForeignKey(s => s.FinancialYearId);
            modelBuilder.Entity<MunicipalitySchedulesEntity>()
                .HasMany<MunicipalityTaxDetailsEntity>(g => g.MunicipalityTaxDetails)
                .WithOne(s => s.MunicipalitySchedules)
                .HasForeignKey(s => s.MunicipalitySchedulesId)
                .IsRequired();
            modelBuilder.Entity<MunicipalityRuleEntity>().HasIndex(c => new { c.MunicipalityId, c.TaxRuleId }).IsUnique();

            // this.modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
