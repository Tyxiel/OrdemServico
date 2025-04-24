using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrdemServico.Models
{
    public partial class DBSenaiTechContext : DbContext
    {
        public DBSenaiTechContext()
        {
        }

        public DBSenaiTechContext(DbContextOptions<DBSenaiTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Defeito> Defeitos { get; set; } = null!;
        public virtual DbSet<Equipamento> Equipamentos { get; set; } = null!;
        public virtual DbSet<OrdensServico> OrdensServicos { get; set; } = null!;
        public virtual DbSet<Tecnico> Tecnicos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__885457EE011734EE");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeCliente");

                entity.HasMany(e => e.OrdensServicos)
                    .WithOne(e => e.IdClienteNavigation)
                    .HasForeignKey(e => e.IdCliente)
                    .HasConstraintName("FK__OrdensSer__idCli__4222D4EF");
            });

            modelBuilder.Entity<Defeito>(entity =>
            {
                entity.HasKey(e => e.IdDefeito)
                    .HasName("PK__Defeitos__9549F9F7BD729DE1");

                entity.Property(e => e.IdDefeito).HasColumnName("idDefeito");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.HasMany(e => e.OrdensServicos)
                    .WithOne(e => e.IdDefeitoNavigation)
                    .HasForeignKey(e => e.IdDefeito)
                    .HasConstraintName("FK__OrdensSer__idDef__4316F928");
            });

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.IdEquipamento)
                    .HasName("PK__Equipame__75940D34D0CF45D2");

                entity.Property(e => e.IdEquipamento).HasColumnName("idEquipamento");

                entity.Property(e => e.NomeEquipamento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeEquipamento");

                entity.HasMany(e => e.OrdensServicos)
                    .WithOne(e => e.IdEquipamentoNavigation)
                    .HasForeignKey(e => e.IdEquipamento)
                    .HasConstraintName("FK__OrdensSer__idEqu__412EB0B6");
            });

            modelBuilder.Entity<OrdensServico>(entity =>
            {
                entity.HasKey(e => e.IdOrdemServico)
                    .HasName("PK__OrdensSe__976593105C89ACCE");

                entity.Property(e => e.IdOrdemServico).HasColumnName("idOrdemServico");

                entity.Property(e => e.DataOrdemServico)
                    .HasColumnType("date")
                    .HasColumnName("dataOrdemServico");

                entity.Property(e => e.Servico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servico");

                entity.Property(e => e.StatusServico)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("statusServico");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valorTotal");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.HasKey(e => e.IdTecnico)
                    .HasName("PK__Tecnicos__295BEDE46571E492");

                entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

                entity.Property(e => e.NomeTecnico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeTecnico");

                entity.HasMany(e => e.OrdensServicos)
                    .WithOne(e => e.IdTecnicoNavigation)
                    .HasForeignKey(e => e.IdTecnico)
                    .HasConstraintName("FK__OrdensSer__idTec__440B1D61");
            });

            modelBuilder.Entity<OrdensServico>(entity =>
            {
                entity.HasOne(e => e.IdClienteNavigation)
        .WithMany(e => e.OrdensServicos)
        .HasForeignKey(e => e.IdCliente)
        .HasConstraintName("FK__OrdensSer__idCli__4222D4EF");

                entity.HasOne(e => e.IdDefeitoNavigation)
                    .WithMany(e => e.OrdensServicos)
                    .HasForeignKey(e => e.IdDefeito)
                    .HasConstraintName("FK__OrdensSer__idDef__4316F928");

                entity.HasOne(e => e.IdEquipamentoNavigation)
                    .WithMany(e => e.OrdensServicos)
                    .HasForeignKey(e => e.IdEquipamento)
                    .HasConstraintName("FK__OrdensSer__idEqu__412EB0B6");

                entity.HasOne(e => e.IdTecnicoNavigation)
                    .WithMany(e => e.OrdensServicos)
                    .HasForeignKey(e => e.IdTecnico)
                    .HasConstraintName("FK__OrdensSer__idTec__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
