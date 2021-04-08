using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IConfigdataRepository
    {
        IEnumerable<Configdata> Configdatas { get; }

        Configdata GetConfigdataById(long Id);

        IEnumerable<Environment> Environments { get; }

        Environment GetEnvironmentById(int id);

        bool InsertEnvironment(Environment environment);
        bool UpdateEnvironment(Environment environment);
        bool DeleteEnvironment(int id);
    }
}
