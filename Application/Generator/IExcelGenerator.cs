using Domain.Entities;
using System.Collections.Generic;

namespace Application.Generator
{
    public interface IExcelGenerator
    {
        public byte[] DocFilling(IReadOnlyList<Metric> metrics);
    }
}
