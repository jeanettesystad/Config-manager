using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories
{
    public class SqlConfigRepository : IConfigdataRepository
    {
        private ConfigManagerContext context;

        public IEnumerable<Configdata> Configdatas => context.Configdatas;
        //public IEnumerable<EnvironmentT> Environments => context.EnvironmentTs;

        public SqlConfigRepository(ConfigManagerContext context)
        {
            this.context = context;
        }

        //public IEnumerable<Configdata> Configdatas;


        public Configdata GetConfigdataById(long id)
        {
            return context.Configdatas
                        //  .Include("Enviro")
                          .Where(c => c.Id == id)
                          .FirstOrDefault();
        }




        /*
        public EnvironmentT GetEnvironmentByName(string name)
        {
                return context.EnvironmentTs
                            .Where(e => e.Name == name)
                            .FirstOrDefault();
        }*/


        public bool CreateConfigdata(Configdata configdata)
        {
            throw new NotImplementedException();
        }

        public bool DeleteConfigdata(long Id)
        {
            throw new NotImplementedException();
        }

        public bool EditConfigdata(long Id)
        {
            throw new NotImplementedException();
        }

        
    }
}
