using APIAgriSus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Agricultor> Agricultores { get; set; }
        public DbSet<Userfisico> Userfisico { get; set; }
        public DbSet<UserJuridico> UserJuridico { get; set; }

    }
}
