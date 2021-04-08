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

        public SqlConfigRepository(ConfigManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Environment> Environments => 
            context.Environments;

        



        public Configdata GetConfigdataById(long id)
        {
            return context.Configdatas
                          .Include("Environment")
                          .Where(c => c.Id == id)
                          .FirstOrDefault();
        }

      


       


        public bool CreateConfigdata(Configdata configdata)
        {
            return false;
        }

        public bool DeleteConfigdata(long Id)
        {
            return false;
        }

        public bool EditConfigdata(long Id)
        {
            return false;
        }

        
    }
}
