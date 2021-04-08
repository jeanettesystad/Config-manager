using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories
{
    public class SqlAdminRepository : IAdminRepository
    {
        private AdminContext context;


        public IEnumerable<Admin> Admins =>
            context.Admins;


        public SqlAdminRepository(AdminContext context)
        {
            this.context = context;
        }


        /*   verifisere tilgang til tabellen? skal seff ikke liste passordene i client
        public Admin GetAdminByUsername(long id)
        {
            return context.Admins
                          .Where(c => c.Id == id)
                          .FirstOrDefault();
        }
        */
      

        

        
    }
}
