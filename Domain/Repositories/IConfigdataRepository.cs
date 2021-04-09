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

        Environment GetEnvironmentById(long id);

        Environment InsertEnvironment(Environment environment);
        bool UpdateEnvironment(Environment environment);
        bool DeleteEnvironment(long id);



        IEnumerable<Admin> Admins { get; }

        Admin GetAdminById(long id);
        string VerifyUser(string username);

    }
}
