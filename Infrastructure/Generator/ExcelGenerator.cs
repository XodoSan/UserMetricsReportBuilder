using OfficeOpenXml;
using System;
using System.Collections.Generic;

namespace Infrastructure.Generator
{
    public class ExcelGenerator : IExcelGenerator
    {
        public byte[] Generate(IReadOnlyList<ExcelEntity> excelEntitys)
        {
            var package = new ExcelPackage();
            ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Report");

            sheet.Column(2).Width = 50;
            sheet.Column(1).Width = 30;
            sheet.Cells["A1"].Value = "Событие UI-метрики:";
            sheet.Cells["B1"].Value = "Расшифровка:";

            string translation;
            for (int i = 0; i < excelEntitys.Count; i++)
            {
                sheet.Cells["A" + (i + 2)].Value = excelEntitys[i].Description;
                translation = TranslateDescriptions(excelEntitys[i].Description);
                sheet.Cells["B" + (i + 2)].Value = translation;
                sheet.Cells["C" + (i + 2)].Value = excelEntitys[i].Counter;
            }

            return package.GetAsByteArray();
        }

        private string TranslateDescriptions(string description)
        {
            return description switch
            {
                "GeneralBookingCharts" => "Продажи и загрузка",
                "OccupancyRate" => "Темп загрузки отеля",
                "SalesDistribution" => "Распределение продаж",
                "BookingWindowcomparisonType:" => "Окно бронирования",
                "CancellationcomparisonType:" => "Статистика отмен",
                "DemandCalendar" => "Календарь спроса",
                "OpenDashboard" => "Переход",
                "Analyser" => "Клик по задаче",
                "Extranet" => "Бронирование из Extranet",
                "ConversionDashboard" => "Статистика по конверсиям",
                _ => throw new ArgumentException("Invalid description"),
            };
        }
    }
}
