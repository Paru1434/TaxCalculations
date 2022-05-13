﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaxCalculation.Repository.DBContext;

namespace TaxCalculation.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220513092946_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TaxCalculation.Common.Entities.FinancialYearEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdat");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("RangeFrom")
                        .HasColumnType("date")
                        .HasColumnName("rangefrom");

                    b.Property<DateTime?>("RangeTo")
                        .HasColumnType("date")
                        .HasColumnName("rangeto");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedat");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updatedby");

                    b.HasKey("Id");

                    b.ToTable("financialyear");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.MunicipalityEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdat");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("createdby");

                    b.Property<string>("MunicipalityName")
                        .HasColumnType("text")
                        .HasColumnName("municipalityname");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedat");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updatedby");

                    b.HasKey("Id");

                    b.ToTable("municipality");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.MunicipalityRuleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdat");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("createdby");

                    b.Property<long>("MunicipalityId")
                        .HasColumnType("bigint")
                        .HasColumnName("municipalityid");

                    b.Property<long>("TaxRuleId")
                        .HasColumnType("bigint")
                        .HasColumnName("taxruleid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedat");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updatedby");

                    b.HasKey("Id");

                    b.HasIndex("TaxRuleId");

                    b.HasIndex("MunicipalityId", "TaxRuleId")
                        .IsUnique();

                    b.ToTable("municipalityrule");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.MunicipalitySchedulesEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdat");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("createdby");

                    b.Property<string>("Period")
                        .HasColumnType("text")
                        .HasColumnName("period");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedat");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updatedby");

                    b.HasKey("Id");

                    b.ToTable("municipalityschedules");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.MunicipalityTaxDetailsEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdat");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("createdby");

                    b.Property<long?>("FinancialYearId")
                        .HasColumnType("bigint")
                        .HasColumnName("financialyearid");

                    b.Property<long>("MunicipalitySchedulesId")
                        .HasColumnType("bigint")
                        .HasColumnName("municipalityschedulesid");

                    b.Property<decimal>("Tax")
                        .HasColumnType("numeric(38,17)")
                        .HasColumnName("tax");

                    b.Property<long>("TaxRuleId")
                        .HasColumnType("bigint")
                        .HasColumnName("taxruleid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedat");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updatedby");

                    b.HasKey("Id");

                    b.HasIndex("FinancialYearId");

                    b.HasIndex("MunicipalitySchedulesId");

                    b.HasIndex("TaxRuleId");

                    b.ToTable("municipalitytaxdetails");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.TaxRulesEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdat");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("createdby");

                    b.Property<string>("Rule")
                        .HasColumnType("text")
                        .HasColumnName("rule");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedat");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updatedby");

                    b.HasKey("Id");

                    b.ToTable("taxrules");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.MunicipalityRuleEntity", b =>
                {
                    b.HasOne("TaxCalculation.Common.Entities.MunicipalityEntity", "Municipality")
                        .WithMany("MunicipalityRule")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxCalculation.Common.Entities.TaxRulesEntity", "TaxRule")
                        .WithMany("MunicipalityRule")
                        .HasForeignKey("TaxRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipality");

                    b.Navigation("TaxRule");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.MunicipalityTaxDetailsEntity", b =>
                {
                    b.HasOne("TaxCalculation.Common.Entities.FinancialYearEntity", "FinancialYear")
                        .WithMany("MunicipalityTaxDetails")
                        .HasForeignKey("FinancialYearId");

                    b.HasOne("TaxCalculation.Common.Entities.MunicipalitySchedulesEntity", "MunicipalitySchedules")
                        .WithMany("MunicipalityTaxDetails")
                        .HasForeignKey("MunicipalitySchedulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxCalculation.Common.Entities.TaxRulesEntity", "TaxRule")
                        .WithMany("MunicipalityTaxDetails")
                        .HasForeignKey("TaxRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinancialYear");

                    b.Navigation("MunicipalitySchedules");

                    b.Navigation("TaxRule");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.FinancialYearEntity", b =>
                {
                    b.Navigation("MunicipalityTaxDetails");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.MunicipalityEntity", b =>
                {
                    b.Navigation("MunicipalityRule");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.MunicipalitySchedulesEntity", b =>
                {
                    b.Navigation("MunicipalityTaxDetails");
                });

            modelBuilder.Entity("TaxCalculation.Common.Entities.TaxRulesEntity", b =>
                {
                    b.Navigation("MunicipalityRule");

                    b.Navigation("MunicipalityTaxDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
