using Domain.Entities;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories
{
    public class SqlConfigRepository : IConfigdataRepository
    {
        private ConfigManagerContext context;

        public IEnumerable<Configdata> Configdatas => 
            context.Configdatas;

        public IEnumerable<Environment> Environments =>
            context.Environments.Include("Configdatas");


        public SqlConfigRepository(ConfigManagerContext context)
        {
            this.context = context;
        }

        public Configdata GetConfigdataById(long id)
        {
            return context.Configdatas
                          .Where(c => c.Id == id)
                          .FirstOrDefault();
        }

      
        public bool InsertConfigdata(Configdata configdata)
        {
            context.Configdatas.Add(configdata);
            return SaveAndReturnTrue();
        }

        public bool DeleteConfigdata(long id)
        {
            context.Configdatas.Remove(GetConfigdataById(id));
            return SaveAndReturnTrue();
        }

        public bool UpdateConfigdata(Configdata configdata)
        {
            context.Configdatas.Update(configdata);
            return SaveAndReturnTrue();
        }

        public Environment GetEnvironmentById(long id)
        {
            return context.Environments
                          .Include("Configdatas")
                          .Where(e => e.Id == id)
                          .FirstOrDefault();
        }

        public Environment InsertEnvironment(Environment environment)
        {
            context.Environments.Add(environment);
            context.SaveChanges();

            return environment;
        }

        public bool UpdateEnvironment(Environment environment)
        {
            context.Environments.Update(environment);
            return SaveAndReturnTrue();
        }

        public bool DeleteEnvironment(long id)
        {
            context.Environments.Remove(GetEnvironmentById(id));
            return SaveAndReturnTrue();
        }

        public bool SaveAndReturnTrue()
        {
            context.SaveChanges();
            return true;
        }
    }
}
