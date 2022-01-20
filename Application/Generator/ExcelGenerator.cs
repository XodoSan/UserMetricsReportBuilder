using Domain.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;

namespace Application.Generator
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
            sheet.Cells["C1"].Value = " ";

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
            switch (description)
            {
                case "GeneralBookingCharts":
                    return "Продажи и загрузка";
                case "OccupancyRate":
                    return "Темп загрузки отеля";
                case "SalesDistribution":
                    return "";
                case "BookingWindowcomparisonType:":
                    return "Окно бронирования";
                case "CancellationcomparisonType:":
                    return "Статистика отмен";
                case "DemandCalendar":
                    return "Календарь спроса";
                case "OpenDashboard":
                    return "Переход";
                case "Analyser":
                    return "Клик по задаче";
                case "Extranet":
                    return "Бронирование из Extranet";
                case "ConversionDashboard":
                    return "Статистика по конверсиям";
                default:
                    throw new ArgumentException("Invalid description");
            }
        }
    }
}
