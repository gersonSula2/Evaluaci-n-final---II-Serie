
using Microsoft.EntityFrameworkCore;
using ClienteAPI_EF.Models;

namespace ClienteAPI_EF.Data
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<InformacionCliente> InformacionClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InformacionCliente>()
                .HasOne(ic => ic.Cliente)
                .WithMany()
                .HasForeignKey(ic => ic.ClienteID);
        }
    }
}