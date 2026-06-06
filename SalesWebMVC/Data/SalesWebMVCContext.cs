using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext(DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; } = default!;
        public DbSet<Vendedores> Vendedores { get; set; } = default!;
        public DbSet<VendasRecord> VendasRecords { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VendasRecord>()
            .HasOne(v => v.Vendedores)
            .WithMany(v => v.Vendas)
            .HasForeignKey(v => v.VendedoresId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}



