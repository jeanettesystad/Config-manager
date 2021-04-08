using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Domain.Repositories
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options)
                : base(options)
        { }

        public DbSet<Admin> Admins { get; set; }
           
    }
}
