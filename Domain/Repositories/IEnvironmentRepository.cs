using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEnvironmentRepository
    {
        IEnumerable<EnvironmentT> Environments { get; }

        EnvironmentT GetDescription(string name);

    }
}
