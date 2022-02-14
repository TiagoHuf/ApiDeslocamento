using ApiDeslocamento.Data.Mapping;
using ApiDeslocamento.Domain.Entities;
using ApiDeslocamnento.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opcoes) : base(opcoes)
        {

        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Carro> Carro { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Condutor> Condutor { get; set; }

        public DbSet<Deslocamentos> Deslocamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carro>(new CarroConfiguration().Configure);
            modelBuilder.Entity<Cliente>(new ClienteConfiguration().Configure);
            modelBuilder.Entity<Condutor>(new CondutorConfiguration().Configure);
            modelBuilder.Entity<Deslocamentos>(new DeslocamentoConfiguration().Configure);
        }
    }
}
