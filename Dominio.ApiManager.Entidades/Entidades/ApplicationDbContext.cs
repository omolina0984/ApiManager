using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dominio.ApiManager.Entidades.Entidades
{
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
        public virtual DbSet<Cuentum> Cuenta { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<TipoCuentum> TipoCuenta { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NTUPFJ7;Database=MovimientoBanca;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Contraseña).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Genero).IsUnicode(false);

                entity.Property(e => e.Identificacion).IsUnicode(false);

                entity.Property(e => e.Nombres).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Cuenta_Cliente");

                entity.HasOne(d => d.TipoCuenta)
                    .WithMany(p => p.CuentaNavigation)
                    .HasForeignKey(d => d.TipoCuentaId)
                    .HasConstraintName("FK_Cuenta_TipoCuenta");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.Property(e => e.Detalle).IsUnicode(false);

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.CuentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimientos_Cuenta");

                entity.HasOne(d => d.TipoMovimiento)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.TipoMovimientoId)
                    .HasConstraintName("FK_Movimientos_TipoMovimiento");
            });

            modelBuilder.Entity<TipoCuentum>(entity =>
            {
                entity.Property(e => e.TipoCuentaId).ValueGeneratedNever();

                entity.Property(e => e.Cuenta).IsUnicode(false);
            });

            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
                entity.Property(e => e.TipoMovimientoId).ValueGeneratedNever();

                entity.Property(e => e.DescripcionMovimiento).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
