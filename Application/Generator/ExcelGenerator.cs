using Domain.Entities;
using OfficeOpenXml;
using System.Collections.Generic;

namespace Application.Generator
{
    public class ExcelGenerator : IExcelGenerator
    {
        public byte[] Generate(IReadOnlyList<Metric> metrics)
        {
            var package = new ExcelPackage();
            ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Report");

            sheet.Cells["A1"].Value = "Id:";
            sheet.Cells["B1"].Value = "Description:";
            sheet.Cells["C1"].Value = "Timestamp:";
            sheet.Cells["D1"].Value = "Type:";
            sheet.Cells["E1"].Value = "IpAddress:";
            sheet.Cells["F1"].Value = "ProviderId:";
            sheet.Cells["G1"].Value = "UserName:";

            for (int i = 0; i < metrics.Count; i++)
            {
                sheet.Cells["A" + (i + 2)].Value = metrics[i].MetricId;
                sheet.Cells["B" + (i + 2)].Value = metrics[i].Description;
                sheet.Cells["C" + (i + 2)].Value = metrics[i].Timestamp;
                sheet.Cells["D" + (i + 2)].Value = metrics[i].Type;
                sheet.Cells["E" + (i + 2)].Value = metrics[i].IpAddress;
                sheet.Cells["F" + (i + 2)].Value = metrics[i].ProviderId;
                sheet.Cells["G" + (i + 2)].Value = metrics[i].UserName;
            }

            return package.GetAsByteArray();
        }
    }
}
