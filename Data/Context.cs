using GoodTrip.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodTrip.Data
{
    public class Context : DbContext
    {
        public DbSet<Cliente> clientes {get;set;}
        //public DbSet<Telefone> telefones { get;set;}
        public DbSet<Passagem> passagens {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-TOGJFTG; Initial Catalog = AgenciaDeViagens; Integrated Security = SSPI");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(tabela =>
            {
                tabela.ToTable("Cliente");
                tabela.HasKey("Id_cliente");
                tabela.Property("Nome").IsRequired().HasMaxLength(50);
                tabela.Property("Email").IsRequired().HasMaxLength(50);
                tabela.Property("CPF").IsRequired().HasColumnType("char(11)");
                tabela.Property("Sexo").HasColumnType("char(1)").IsRequired();
            });
            /*
            modelBuilder.Entity<Telefone>(tabela =>
            {
                tabela.ToTable("Telefone");
                tabela.HasKey("Id_tel");
                tabela.HasOne<Cliente>(t => t.Cliente).WithMany(c => c.Telefones).HasForeignKey(t => t.Id_cliente_tel);
                tabela.Property("Fixo").HasColumnType("char(10)").IsRequired(false);
                tabela.Property("Celular").HasColumnType("char(11)").IsRequired(false);
            });
            */

            modelBuilder.Entity<Passagem>()
                .ToTable("Passagem")
                .HasKey("Id_pass");

            modelBuilder.Entity<Passagem>()
               .HasOne<Cliente>(p => p.Cliente)
               .WithMany(c => c.Passagens)
               .HasForeignKey(p => p.Id_cliente_pass);
                
            modelBuilder.Entity<Passagem>()
               .Property(p => p.Embarque)
               .IsRequired()
               .HasMaxLength(40);

            modelBuilder.Entity<Passagem>()
               .Property(p => p.Desembarque)
               .IsRequired()
               .HasMaxLength(15);

            modelBuilder.Entity<Passagem>()
               .Property(p => p.preco)
               .HasColumnType("decimal(7,2)")
               .IsRequired();

        }
    }
}
