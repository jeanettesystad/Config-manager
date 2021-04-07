﻿using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Domain.Repositories
{
    public class ConfigManagerContext : DbContext
    {
        public ConfigManagerContext(DbContextOptions<ConfigManagerContext> options)
            : base(options)
        { }

        public DbSet<Configdata> Configdatas { get; set; }
        //public DbSet<EnvironmentT> EnvironmentTs { get; set; }
        //public DbSet<Admin> Admins { get; set; }

    }
}

