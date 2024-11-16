using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace clienteAPI_EF.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<InformacionCliente> InformacionClientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ClientesDB;Username=postgres;Password=123456789");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("'-infinity'::timestamp with time zone");
        });

        modelBuilder.Entity<InformacionCliente>(entity =>
        {
            entity.HasIndex(e => e.ClienteId, "IX_InformacionClientes_ClienteId");

            entity.HasIndex(e => e.ClienteId1, "IX_InformacionClientes_ClienteId1");

            entity.HasOne(d => d.Cliente).WithMany(p => p.InformacionClienteClientes).HasForeignKey(d => d.ClienteId);

            entity.HasOne(d => d.ClienteId1Navigation).WithMany(p => p.InformacionClienteClienteId1Navigations).HasForeignKey(d => d.ClienteId1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
