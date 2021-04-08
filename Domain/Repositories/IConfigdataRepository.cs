using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IConfigdataRepository
    {
        IEnumerable<Configdata> Configdatas { get; }

        Configdata GetConfigdataById(long Id);


    }
}
