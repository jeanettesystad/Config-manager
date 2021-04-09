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
            context.SaveChanges();

            return true;
        }

        public bool DeleteConfigdata(long id)
        {
            return false;
        }

        public bool UpdateConfigdata(Configdata configdata)
        {
            context.Configdatas.Update(configdata);
            context.SaveChanges();

            return true;   
        }

        public Environment GetEnvironmentById(long id)
        {
            return context.Environments
                          .Include("Configdatas")
                          .Where(e => e.Id == id)
                          .FirstOrDefault();
        }

        public bool InsertEnvironment(Environment environment)
        {
            context.Environments.Add(environment);
            context.SaveChanges();

            return true;
        }

        public bool UpdateEnvironment(Environment environment)
        {
            context.Environments.Update(environment);
            context.SaveChanges();

            return true;
        }

        public bool DeleteEnvironment(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
