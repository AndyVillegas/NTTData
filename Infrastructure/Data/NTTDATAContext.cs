using System;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

#nullable disable

namespace Infrastructure.Data
{
    public partial class NTTDATAContext : DbContext
    {
        public NTTDATAContext()
        {
        }

        public NTTDATAContext(DbContextOptions<NTTDATAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Genero)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasQueryFilter(e => e.Estado.Value);
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasIndex(e => e.NumeroCuenta, "UQ_NumeroCuenta")
                    .IsUnique();

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuentas_Clientes");

                entity.HasQueryFilter(e => e.Estado.Value);
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.CuentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimientos_Cuentas");

                entity.HasQueryFilter(e => e.Estado.Value);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
