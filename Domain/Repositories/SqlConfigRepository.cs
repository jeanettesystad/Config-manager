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

        public IEnumerable<Configdata> Configdatas => 
            context.Configdatas.Include("Environment");

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
