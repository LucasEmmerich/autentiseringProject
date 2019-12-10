using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacao.DatabaseContext.Models;
using System;

namespace ProjetoAutenticacao.DatabaseContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions o) : base(o) { }

        public DbSet<TUser> Users { get; set; }
        public DbSet<TEmpresa> Empresas { get; set; }
        public DbSet<TAplicativo> Aplicativos { get; set; }
        public DbSet<TToken> Tokens { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Autenticacao");
            builder.Entity<TUser>(o =>
            {
                o.ToTable("TUserSet");
                o.Property(e => e.Id).ValueGeneratedOnAdd();
                o.HasKey("Id");
                o.Property(e => e.Login).IsRequired();
                o.Property(e => e.Password).IsRequired();
                o.Property(e => e.Excluido).HasColumnType("TINYINT").HasDefaultValue(false);
                o.Property(e => e.DataCriacao).HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
            });
            builder.Entity<TEmpresa>(o =>
            {
                o.ToTable("TEmpresaSet");
                o.Property(e => e.Id).ValueGeneratedOnAdd();
                o.HasKey("Id");
                o.Property(e => e.CNPJ).IsRequired();
                o.Property(e => e.RazaoSocial).IsRequired();
                o.Property(e => e.Excluido).HasColumnType("TINYINT").HasDefaultValue(false);
                o.Property(e => e.DataCriacao).HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
            });
            builder.Entity<TToken>(o =>
            {
                o.ToTable("TTokenSet");
                o.Property(e => e.Id).ValueGeneratedOnAdd();
                o.HasKey("Id");
                o.Property(e => e.Token).IsRequired();
                o.Property(e => e.Validade).HasColumnType("DATETIME").IsRequired();
            });
            builder.Entity<TAplicativo>(o =>
            {
                o.ToTable("TAplicativoSet");
                o.Property(e => e.Id).ValueGeneratedOnAdd();
                o.HasKey("Id");
                o.Property(e => e.AppId).IsRequired();
                o.Property(e => e.Aplicativo).IsRequired();
            });
        }
    }
}
