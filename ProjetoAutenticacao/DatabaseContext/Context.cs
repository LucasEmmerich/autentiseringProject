using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacao.DatabaseContext.Models;

namespace ProjetoAutenticacao.DatabaseContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions o) : base(o) { }

        public DbSet<TUser> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("autenticacao");
            builder.Entity<TUser>(o =>
            {
                o.ToTable("TUserSet");
                o.Property(e => e.Id).ValueGeneratedOnAdd();
                o.HasKey("Id");
                o.Property(e => e.Login).IsRequired();
                o.Property(e => e.Password).IsRequired();
            }) ;
        }
    }
}
