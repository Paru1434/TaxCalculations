using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculation.Repository.Migrations
{
    public partial class nullValue_Tax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "tax",
                schema: "public",
                table: "municipalitytaxdetails",
                type: "numeric(38,17)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(38,17)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "tax",
                schema: "public",
                table: "municipalitytaxdetails",
                type: "numeric(38,17)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(38,17)",
                oldNullable: true);
        }
    }
}
