using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tentando_conectar_no_oracle
{
    public class MyContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=LOCAL;Password=LOCAL;Data Source=localhost:1521/LOCAL");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>().ToTable("Produtos").Property(p => p.Codigo).HasColumnName("Id");
            modelBuilder.Entity<Produto>().ToTable("Produtos").Property(p => p.Descricao).HasColumnName("Descricao");
            modelBuilder.Entity<Produto>().ToTable("Produtos").Property(p => p.DataRegistro).HasColumnName("DataRegistro");


        }
    }
}
