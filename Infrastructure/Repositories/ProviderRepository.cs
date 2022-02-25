using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private AppDBContext _context;

        public ProviderRepository(AppDBContext context)
        {
            _context = context;
        }

        public IReadOnlyList<Provider> GetProvidersByProviderTypes(IEnumerable<ProviderType> providerTypes)
        {
            return _context.Set<Provider>()
                .Where(item => providerTypes.Contains(item.ProviderType))
                .ToList();
        }
    }
}
