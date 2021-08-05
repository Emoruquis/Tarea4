using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CargarDatos.Models
{
    public partial class EmmaElcoBitContext : DbContext
    {
        public EmmaElcoBitContext()
        {
        }

        public EmmaElcoBitContext(DbContextOptions<EmmaElcoBitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EntidadFederativa> EntidadFederativas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=elcobit.database.windows.net;Database=EmmaElcoBit;User ID=dbadmin;Password=4dxEver.21;Trusted_Connection=False;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EntidadFederativa>(entity =>
            {
                entity.HasKey(e => e.EntidadId);

                entity.ToTable("EntidadFederativa");

                entity.Property(e => e.EntidadId)
                    .ValueGeneratedNever()
                    .HasColumnName("EntidadID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAbreviado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
