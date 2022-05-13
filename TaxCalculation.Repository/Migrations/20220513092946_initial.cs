using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TaxCalculation.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "financialyear",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rangefrom = table.Column<DateTime>(type: "date", nullable: false),
                    rangeto = table.Column<DateTime>(type: "date", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updatedat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financialyear", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "municipality",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    municipalityname = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updatedat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipality", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "municipalityschedules",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    period = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updatedat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipalityschedules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "taxrules",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rule = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updatedat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxrules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "municipalityrule",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    municipalityid = table.Column<long>(type: "bigint", nullable: false),
                    taxruleid = table.Column<long>(type: "bigint", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updatedat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipalityrule", x => x.id);
                    table.ForeignKey(
                        name: "FK_municipalityrule_municipality_municipalityid",
                        column: x => x.municipalityid,
                        principalSchema: "public",
                        principalTable: "municipality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_municipalityrule_taxrules_taxruleid",
                        column: x => x.taxruleid,
                        principalSchema: "public",
                        principalTable: "taxrules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "municipalitytaxdetails",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tax = table.Column<decimal>(type: "numeric(38,17)", nullable: false),
                    municipalityschedulesid = table.Column<long>(type: "bigint", nullable: false),
                    taxruleid = table.Column<long>(type: "bigint", nullable: false),
                    financialyearid = table.Column<long>(type: "bigint", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updatedat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipalitytaxdetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_municipalitytaxdetails_financialyear_financialyearid",
                        column: x => x.financialyearid,
                        principalSchema: "public",
                        principalTable: "financialyear",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_municipalitytaxdetails_municipalityschedules_municipalitysc~",
                        column: x => x.municipalityschedulesid,
                        principalSchema: "public",
                        principalTable: "municipalityschedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_municipalitytaxdetails_taxrules_taxruleid",
                        column: x => x.taxruleid,
                        principalSchema: "public",
                        principalTable: "taxrules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_municipalityrule_municipalityid_taxruleid",
                schema: "public",
                table: "municipalityrule",
                columns: new[] { "municipalityid", "taxruleid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_municipalityrule_taxruleid",
                schema: "public",
                table: "municipalityrule",
                column: "taxruleid");

            migrationBuilder.CreateIndex(
                name: "IX_municipalitytaxdetails_financialyearid",
                schema: "public",
                table: "municipalitytaxdetails",
                column: "financialyearid");

            migrationBuilder.CreateIndex(
                name: "IX_municipalitytaxdetails_municipalityschedulesid",
                schema: "public",
                table: "municipalitytaxdetails",
                column: "municipalityschedulesid");

            migrationBuilder.CreateIndex(
                name: "IX_municipalitytaxdetails_taxruleid",
                schema: "public",
                table: "municipalitytaxdetails",
                column: "taxruleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "municipalityrule",
                schema: "public");

            migrationBuilder.DropTable(
                name: "municipalitytaxdetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "municipality",
                schema: "public");

            migrationBuilder.DropTable(
                name: "financialyear",
                schema: "public");

            migrationBuilder.DropTable(
                name: "municipalityschedules",
                schema: "public");

            migrationBuilder.DropTable(
                name: "taxrules",
                schema: "public");
        }
    }
}
