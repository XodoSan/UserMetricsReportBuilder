using OfficeOpenXml;
using System.Collections.Generic;

namespace Application.Generator
{
    public class ExcelGenerator : IExcelGenerator
    {
        public byte[] Generate(IReadOnlyList<ExcelEntity> excelEntitys)
        {
            var package = new ExcelPackage();
            ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Report");

            sheet.Column(2).Width = 70;
            sheet.Column(1).Width = 20;
            sheet.Cells["A1"].Value = "Событие UI-метрики:";
            sheet.Cells["B1"].Value = "Расшифровка:";
            sheet.Cells["C1"].Value = " ";

            for (int i = 0; i < excelEntitys.Count; i++)
            {
                sheet.Cells["B" + (i + 2)].Value = excelEntitys[i].Description;
                sheet.Cells["C" + (i + 2)].Value = excelEntitys[i].Counter;
            }

            return package.GetAsByteArray();
        }
    }
}
