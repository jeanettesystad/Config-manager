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
            context.Configdatas.Include("Environment");

        public IEnumerable<Environment> Environments =>
            context.Environments;


        public SqlConfigRepository(ConfigManagerContext context)
        {
            this.context = context;
        }



        public Configdata GetConfigdataById(long id)
        {
            return context.Configdatas
                          .Include("Environment")
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
            return false;
        }

        public Environment GetEnvironmentById(int id)
        {
            return context.Environments
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
            throw new System.NotImplementedException();
        }

        public bool DeleteEnvironment(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
