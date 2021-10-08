using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMetricsReportBuilderApi.Migrations
{
    public partial class FixedNameOfColoumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Metrics",
                newName: "MetricId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetricId",
                table: "Metrics",
                newName: "Id");
        }
    }
}
