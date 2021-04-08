using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEnvironmentRepository
    {
        IEnumerable<Environment> Environments { get; } 

    }
}
