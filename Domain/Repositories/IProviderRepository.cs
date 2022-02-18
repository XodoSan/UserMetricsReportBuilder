using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IProviderRepository
    {
        IReadOnlyList<Provider> GetProvidersByProviderTypes(IEnumerable<ProviderType> providerTypes);
    }
}
