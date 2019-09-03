using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.AutosPecas.WebApi.Domains
{
    public partial class AutoPecasContext : DbContext
    {
        public AutoPecasContext()
        {
        }

        public AutoPecasContext(DbContextOptions<AutoPecasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Pecas> Pecas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=T_AutoPecas;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedores>(entity =>
            {
                entity.HasKey(e => e.IdFonercedor);

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Forneced__A299CC92E45E6246")
                    .IsUnique();

                entity.Property(e => e.IdFonercedor).HasColumnName("idFonercedor");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPecasNavigation)
                    .WithMany(p => p.Fornecedores)
                    .HasForeignKey(d => d.IdPecas)
                    .HasConstraintName("FK__Fornecedo__IdPec__5070F446");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Fornecedores)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Fornecedo__IdUsu__4F7CD00D");
            });

            modelBuilder.Entity<Pecas>(entity =>
            {
                entity.HasKey(e => e.IdPeca);

                entity.Property(e => e.CodigoPeca)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.Peso)
                    .IsRequired()
                    .HasColumnName("peso")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoDeCusto)
                    .IsRequired()
                    .HasColumnName("precoDeCusto")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D1053499442648")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
