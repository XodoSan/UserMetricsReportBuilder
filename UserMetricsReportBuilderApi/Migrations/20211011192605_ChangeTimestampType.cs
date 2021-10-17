using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMetricsReportBuilderApi.Migrations
{
    public partial class ChangeTimestampType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Metrics",
                table: "Metrics");

            migrationBuilder.RenameTable(
                name: "Metrics",
                newName: "Domain.Entities.Metrics");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Domain.Entities.Metrics",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domain.Entities.Metrics",
                table: "Domain.Entities.Metrics",
                column: "MetricId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Domain.Entities.Metrics",
                table: "Domain.Entities.Metrics");

            migrationBuilder.RenameTable(
                name: "Domain.Entities.Metrics",
                newName: "Metrics");

            migrationBuilder.AlterColumn<int>(
                name: "Timestamp",
                table: "Metrics",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Metrics",
                table: "Metrics",
                column: "MetricId");
        }
    }
}
