using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IConfigdataRepository
    {
        IEnumerable<Configdata> Configdatas { get; }

        Configdata GetConfigdataById(long Id);

        bool InsertConfigdata(Configdata configdata);
        bool UpdateConfigdata(Configdata configdata);
        bool DeleteConfigdata(long id);




        IEnumerable<Environment> Environments { get; }

        Environment GetEnvironmentById(int id);

        

        bool InsertEnvironment(Environment environment);
        bool UpdateEnvironment(Environment environment);
        bool DeleteEnvironment(long id);
    }
}
