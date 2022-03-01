using Microsoft.EntityFrameworkCore;
using Modelos;
using ModelosEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SocaContext : DbContext
    {
        public DbSet<Tenant> Tenant { get; set; }
        public SocaContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TenantEstructura());            
        }
    }
}
