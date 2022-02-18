using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application
{
    public interface IFileResultGenerator
    {
        public FileResult CreateFile(int year, IEnumerable<ProviderType> providerTypes, string contentType);
    }
}
