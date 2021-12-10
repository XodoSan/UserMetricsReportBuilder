using Domain.Entities;
using OfficeOpenXml;
using System.Collections.Generic;

namespace Application.Generator
{
    public class ExcelGenerator : IExcelGenerator
    {
        public byte[] DocFilling(IReadOnlyList<Metric> metrics)
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Report");

            for (int i = 0; i < metrics.Count; i++)
            {
                sheet.Cells["A1"].Value = "Id:";
                sheet.Cells["A" + i + 2].Value = metrics[i].MetricId;

                sheet.Cells["B1"].Value = "Description:";
                sheet.Cells["B" + i + 2].Value = metrics[i].Description;

                sheet.Cells["C1"].Value = "Timestamp:";
                sheet.Cells["C" + i + 2].Value = metrics[i].Timestamp;

                sheet.Cells["D1"].Value = "Type:";
                sheet.Cells["D" + i + 2].Value = metrics[i].Type;

                sheet.Cells["E1"].Value = "IpAddress:";
                sheet.Cells["E" + i + 2].Value = metrics[i].IpAddress;

                sheet.Cells["F1"].Value = "ProviderId:";
                sheet.Cells["F" + i + 2].Value = metrics[i].ProviderId;

                sheet.Cells["G1"].Value = "UserName:";
                sheet.Cells["G" + i + 2].Value = metrics[i].UserName;
            }

            return package.GetAsByteArray();
        }
    }
}
