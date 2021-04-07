using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IConfigdataRepository
    {
        IEnumerable<Configdata> Configdatas { get; }

        Configdata Get(long Id);

        bool CreateConfigdata(Configdata configdata);
        bool EditConfigdata(long Id);
        bool DeleteConfigdata(long Id);

    }
}
