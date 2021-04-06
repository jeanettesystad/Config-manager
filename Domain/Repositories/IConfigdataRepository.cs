using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IConfigdataRepository
    {
        IEnumerable<Configdata> Configdatas { get; }

        Configdata Get(string configName, string application, string environmentName);

        bool CreateConfigdata(Configdata configdata);
        bool EditConfigdata(string configName, string application, string environmentName);
        bool DeleteConfigdata(string configName, string application, string environmentName);

    }
}
