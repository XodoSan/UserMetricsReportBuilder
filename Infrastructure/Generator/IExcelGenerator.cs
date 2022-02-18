using System.Collections.Generic;

namespace Infrastructure.Generator
{
    public interface IExcelGenerator
    {
        public byte[] Generate(IReadOnlyList<ExcelEntity> excelEntity);
    }
}
