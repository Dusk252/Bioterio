﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bioterio.Models
{
    public partial class bd_lesContext : IdentityDbContext
    {
        public virtual DbSet<AgenteTrat> AgenteTrat { get; set; }
        public virtual DbSet<ApplicationUsers> ApplicationUsers { get; set; }
        public virtual DbSet<CircuitoTanque> CircuitoTanque { get; set; }
        public virtual DbSet<Concelho> Concelho { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Elementoequipa> Elementoequipa { get; set; }
        public virtual DbSet<Ensaio> Ensaio { get; set; }
        public virtual DbSet<Especie> Especie { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<Finalidade> Finalidade { get; set; }
        public virtual DbSet<Fornecedorcolector> Fornecedorcolector { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Localcaptura> Localcaptura { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<LoteSubLote> LoteSubLote { get; set; }
        public virtual DbSet<Motivo> Motivo { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PlanoAlimentar> PlanoAlimentar { get; set; }
        public virtual DbSet<Projeto> Projeto { get; set; }
        public virtual DbSet<ProfileRole> ProfileRole { get; set; }
        public virtual DbSet<RegAlimentar> RegAlimentar { get; set; }
        public virtual DbSet<RegAmostragens> RegAmostragens { get; set; }
        public virtual DbSet<RegCondAmb> RegCondAmb { get; set; }
        public virtual DbSet<RegManutencao> RegManutencao { get; set; }
        public virtual DbSet<RegNovosAnimais> RegNovosAnimais { get; set; }
        public virtual DbSet<RegRemocoes> RegRemocoes { get; set; }
        public virtual DbSet<RegTratamento> RegTratamento { get; set; }
        public virtual DbSet<Tanque> Tanque { get; set; }
        public virtual DbSet<Tipoestatutogenetico> Tipoestatutogenetico { get; set; }
        public virtual DbSet<TipoManuntecao> TipoManuntecao { get; set; }
        public virtual DbSet<TOrigem> TOrigem { get; set; }

        public bd_lesContext(DbContextOptions<bd_lesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<ApplicationUsers>(entity =>
            {
                entity.Property(e => e.FuncionarioIdFuncionario)
                    .HasColumnName("IdFuncionario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FuncionarioNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.FuncionarioIdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FuncionarioIdFuncionario");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("IdPerfil")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PerfilNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PerfilId");
            });

            modelBuilder.Entity<AgenteTrat>(entity =>
            {
                entity.HasKey(e => e.IdAgenTra);

                entity.ToTable("agente_trat");

                entity.Property(e => e.IdAgenTra)
                    .HasColumnName("idAgenTra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeAgenTra)
                    .IsRequired()
                    .HasColumnName("nomeAgenTra")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<CircuitoTanque>(entity =>
            {
                entity.HasKey(e => e.IdCircuito);

                entity.ToTable("circuito_tanque");

                entity.HasIndex(e => e.ProjetoIdProjeto)
                    .HasName("fk_Circuito_Tanque_Projeto1_idx");

                entity.Property(e => e.IdCircuito)
                    .HasColumnName("idCircuito")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoCircuito)
                    .HasColumnName("codigoCircuito")
                    .HasMaxLength(15);

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("dataCriacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataFinal)
                    .HasColumnName("dataFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjetoIdProjeto)
                    .HasColumnName("Projeto_idProjeto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.isarchived)
                    .HasColumnName("isarchived")
                    .HasColumnType("int(1)");

                entity.HasOne(d => d.ProjetoIdProjetoNavigation)
                    .WithMany(p => p.CircuitoTanque)
                    .HasForeignKey(d => d.ProjetoIdProjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Circuito_Tanque_Projeto1");
            });

            modelBuilder.Entity<Concelho>(entity =>
            {
                entity.HasKey(e => e.IdConcelho);

                entity.ToTable("concelho");

                entity.HasIndex(e => e.DistritoId)
                    .HasName("fk_Concelho_Distrito1_idx");

                entity.Property(e => e.IdConcelho)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistritoId)
                    .HasColumnName("Distrito_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeConcelho)
                    .IsRequired()
                    .HasColumnName("nomeConcelho")
                    .HasMaxLength(45);

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Concelho)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Concelho_Distrito1");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdDistrito);

                entity.ToTable("distrito");

                entity.Property(e => e.IdDistrito)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeDistrito)
                    .HasColumnName("nomeDistrito")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Elementoequipa>(entity =>
            {
                entity.HasKey(e => e.IdElementoEquipa);

                entity.ToTable("elementoequipa");

                entity.HasIndex(e => e.FuncionarioIdFuncionario)
                    .HasName("fk_equipaProjeto_Funcionario1");

                entity.HasIndex(e => e.ProjetoIdProjeto)
                    .HasName("fk_equipaProjeto_Projeto1");

                entity.Property(e => e.IdElementoEquipa)
                    .HasColumnName("idElementoEquipa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FuncionarioIdFuncionario)
                    .HasColumnName("Funcionario_idFuncionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Funcao)
                    .IsRequired()
                    .HasColumnName("funcao")
                    .HasMaxLength(40);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(50);

                entity.Property(e => e.ProjetoIdProjeto)
                    .HasColumnName("Projeto_idProjeto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FuncionarioIdFuncionarioNavigation)
                    .WithMany(p => p.Elementoequipa)
                    .HasForeignKey(d => d.FuncionarioIdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipaProjeto_Funcionario1");

                entity.HasOne(d => d.ProjetoIdProjetoNavigation)
                    .WithMany(p => p.Elementoequipa)
                    .HasForeignKey(d => d.ProjetoIdProjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipaProjeto_Projeto1");

                entity.Property(e => e.isarchived)
                    .HasColumnName("isarchived")
                    .HasColumnType("int(1)");
            });

            modelBuilder.Entity<Ensaio>(entity =>
            {
                entity.HasKey(e => e.IdEnsaio);

                entity.ToTable("ensaio");

                entity.HasIndex(e => e.LoteIdLote)
                    .HasName("fk_Ensaio_Lote1");

                entity.HasIndex(e => e.ProjetoIdProjeto)
                    .HasName("fk_Ensaio_Projeto1");

                entity.Property(e => e.IdEnsaio)
                    .HasColumnName("idEnsaio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataFim)
                    .HasColumnName("dataFim")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescTratamento)
                    .IsRequired()
                    .HasColumnName("descTratamento")
                    .HasMaxLength(45);

                entity.Property(e => e.GrauSeveridade)
                    .HasColumnName("grauSeveridade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoteIdLote)
                    .HasColumnName("Lote_idLote")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProjetoIdProjeto)
                    .HasColumnName("Projeto_idProjeto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.LoteIdLoteNavigation)
                    .WithMany(p => p.Ensaio)
                    .HasForeignKey(d => d.LoteIdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ensaio_Lote1");

                entity.HasOne(d => d.ProjetoIdProjetoNavigation)
                    .WithMany(p => p.Ensaio)
                    .HasForeignKey(d => d.ProjetoIdProjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ensaio_Projeto1");

                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");

                entity.Property(e => e.NroAnimaisAutoriz)
                    .HasColumnName("nroAnimaisAutoriz")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Especie>(entity =>
            {
                entity.HasKey(e => e.IdEspecie);

                entity.ToTable("especie");

                entity.HasIndex(e => e.FamiliaIdFamilia)
                    .HasName("fk_Especie_Familia1_idx");

                entity.HasIndex(e => e.GrupoIdGrupo)
                    .HasName("fk_Especie_Grupo1_idx");

                entity.Property(e => e.IdEspecie)
                    .HasColumnName("idEspecie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FamiliaIdFamilia)
                    .HasColumnName("Familia_idFamilia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GrupoIdGrupo)
                    .HasColumnName("Grupo_idGrupo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeCient).HasMaxLength(45);

                entity.Property(e => e.NomeVulgar).HasMaxLength(45);

                entity.HasOne(d => d.FamiliaIdFamiliaNavigation)
                    .WithMany(p => p.Especie)
                    .HasForeignKey(d => d.FamiliaIdFamilia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Especie_Familia1");

                entity.HasOne(d => d.GrupoIdGrupoNavigation)
                    .WithMany(p => p.Especie)
                    .HasForeignKey(d => d.GrupoIdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Especie_Grupo1");
            });

            modelBuilder.Entity<Familia>(entity =>
            {
                entity.HasKey(e => e.IdFamilia);

                entity.ToTable("familia");

                entity.HasIndex(e => e.GrupoIdGrupo)
                    .HasName("fk_Familia_Grupo1_idx");

                entity.Property(e => e.IdFamilia)
                    .HasColumnName("idFamilia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GrupoIdGrupo)
                    .HasColumnName("Grupo_idGrupo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeFamilia).HasMaxLength(45);

                entity.HasOne(d => d.GrupoIdGrupoNavigation)
                    .WithMany(p => p.Familia)
                    .HasForeignKey(d => d.GrupoIdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Familia_Grupo1");
            });

            modelBuilder.Entity<Finalidade>(entity =>
            {
                entity.HasKey(e => e.IdFinalidade);

                entity.ToTable("finalidade");

                entity.Property(e => e.IdFinalidade)
                    .HasColumnName("idFinalidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TFinalidade)
                    .HasColumnName("T_Finalidade")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Fornecedorcolector>(entity =>
            {
                entity.HasKey(e => e.IdFornColect);

                entity.ToTable("fornecedorcolector");

                entity.Property(e => e.IdFornColect)
                    .HasColumnName("idFornColect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Morada).HasMaxLength(45);

                entity.Property(e => e.Nif)
                    .HasColumnName("NIF")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Nome).HasMaxLength(45);

                entity.Property(e => e.NroLicenca)
                    .HasColumnName("nroLicenca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(10);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnType("char(1)");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario);

                entity.ToTable("funcionario");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("idFuncionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeCompleto)
                        .IsRequired()
                        .HasColumnName("nomeCompleto")
                        .HasMaxLength(45);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.ToTable("grupo");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("idGrupo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeGrupo).HasMaxLength(45);
            });

            modelBuilder.Entity<Localcaptura>(entity =>
            {
                entity.HasKey(e => e.IdLocalCaptura);

                entity.ToTable("localcaptura");

                entity.HasIndex(e => e.ConcelhoId)
                    .HasName("fk_LocalCaptura_Concelho1_idx");

                entity.HasIndex(e => e.DistritoId)
                    .HasName("fk_LocalCaptura_Distrito1");

                entity.Property(e => e.IdLocalCaptura)
                    .HasColumnName("idLocalCaptura")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConcelhoId)
                    .HasColumnName("Concelho_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistritoId)
                    .HasColumnName("Distrito_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude).HasColumnType("float(10,6)");

                entity.Property(e => e.Localidade).HasMaxLength(45);

                entity.Property(e => e.Longitude).HasColumnType("float(10,6)");

                entity.HasOne(d => d.Concelho)
                    .WithMany(p => p.Localcaptura)
                    .HasForeignKey(d => d.ConcelhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LocalCaptura_Concelho1");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Localcaptura)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LocalCaptura_Distrito1");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote);

                entity.ToTable("lote");

                entity.HasIndex(e => e.FuncionarioIdFuncionario)
                    .HasName("fk_Lote_Funcionario1_idx");

                entity.HasIndex(e => e.RegNovosAnimaisIdRegAnimal)
                    .HasName("fk_Lote_Reg_Novos_Animais1_idx");

                entity.Property(e => e.IdLote)
                    .HasColumnName("idLote")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoLote)
                    .IsRequired()
                    .HasColumnName("codigoLote")
                    .HasMaxLength(10);

                entity.Property(e => e.DataFim)
                    .HasColumnName("dataFim")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.FuncionarioIdFuncionario)
                    .HasColumnName("Funcionario_idFuncionario");

                entity.Property(e => e.Observacoes).HasMaxLength(45);

                entity.Property(e => e.RegNovosAnimaisIdRegAnimal)
                    .HasColumnName("Reg_Novos_Animais_idRegAnimal")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FuncionarioIdFuncionarioNavigation)
                    .WithMany(p => p.Lote)
                    .HasForeignKey(d => d.FuncionarioIdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Lote_Funcionario1");

                entity.HasOne(d => d.RegNovosAnimaisIdRegAnimalNavigation)
                    .WithMany(p => p.Lote)
                    .HasForeignKey(d => d.RegNovosAnimaisIdRegAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Lote_Reg_Novos_Animais1");
            });

            modelBuilder.Entity<LoteSubLote>(entity =>
            {
                entity.HasKey(e => new { e.LoteIdLotePrev, e.LoteIdLoteAtual });

                entity.ToTable("lote_sub_lote");

                entity.HasIndex(e => e.LoteIdLoteAtual)
                    .HasName("fk_Sub_Lote_Lote2_idx");

                entity.HasIndex(e => e.LoteIdLotePrev)
                    .HasName("fk_Sub_Lote_Lote1_idx");

                entity.Property(e => e.LoteIdLotePrev)
                    .HasColumnName("Lote_idLote_prev")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoteIdLoteAtual)
                    .HasColumnName("Lote_idLote_atual")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoSubLote)
                    .IsRequired()
                    .HasColumnName("codigoSubLote")
                    .HasMaxLength(15);

                entity.HasOne(d => d.LoteIdLoteAtualNavigation)
                    .WithMany(p => p.LoteSubLoteLoteIdLoteAtualNavigation)
                    .HasForeignKey(d => d.LoteIdLoteAtual)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Sub_Lote_Lote2");

                entity.HasOne(d => d.LoteIdLotePrevNavigation)
                    .WithMany(p => p.LoteSubLoteLoteIdLotePrevNavigation)
                    .HasForeignKey(d => d.LoteIdLotePrev)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Sub_Lote_Lote1");
            });

            modelBuilder.Entity<Motivo>(entity =>
            {
                entity.HasKey(e => e.IdMotivo);

                entity.ToTable("motivo");

                entity.Property(e => e.IdMotivo)
                    .HasColumnName("idMotivo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeMotivo)
                    .IsRequired()
                    .HasColumnName("nomeMotivo")
                    .HasMaxLength(45);

                entity.Property(e => e.TipoMotivo)
                    .IsRequired()
                    .HasColumnName("tipoMotivo")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.ToTable("perfil");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("IdPerfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomePerfil)
                    .IsRequired()
                    .HasColumnName("nomePerfil")
                    .HasMaxLength(45);

                entity.Property(e => e.IsDefault)
                    .HasColumnName("IsDefault")
                    .HasColumnType("int(1)");
            });

            modelBuilder.Entity<PlanoAlimentar>(entity =>
            {
                entity.HasKey(e => e.IdPlanAlim);

                entity.ToTable("plano_alimentar");

                entity.Property(e => e.IdPlanAlim)
                    .HasColumnName("idPlanAlim")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MarcaAlim).HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Tipo).HasColumnType("int(11)");
            });

            modelBuilder.Entity<ProfileRole>(entity =>
            {
                entity.HasKey(e => new { e.IdPerfil, e.RoleId });

                entity.ToTable("profilerole");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("IdPerfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleId")
                    .HasColumnType("nvarchar(256)");

                entity.HasIndex(e => e.IdPerfil)
                     .HasName("fk_ProfileRole_Profile_idx");

                entity.HasIndex(e => e.RoleId)
                    .HasName("fk_ProfileRole_Role_idx");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IdPerfil");
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto);

                entity.ToTable("projeto");

                entity.Property(e => e.IdProjeto)
                    .HasColumnName("idProjeto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AutorizacaoDgva)
                    .HasColumnName("AutorizacaoDGVA")
                    .HasMaxLength(45);

                entity.Property(e => e.DataFim)
                    .HasColumnName("dataFim")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.NroAnimaisAutoriz)
                    .HasColumnName("nroAnimaisAutoriz")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RefOrbea)
                    .HasColumnName("RefORBEA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubmisInsEurop).HasColumnType("tinyint(1)");

                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");
            });

            modelBuilder.Entity<RegAlimentar>(entity =>
            {
                entity.HasKey(e => e.IdRegAlim);

                entity.ToTable("reg_alimentar");

                entity.HasIndex(e => e.PlanoAlimentarIdPlanAlim)
                    .HasName("fk_Reg_Alimentar_Plano_Alimentar1");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Alimentar_Tanque1");

                entity.Property(e => e.IdRegAlim)
                    .HasColumnName("idRegAlim")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlanoAlimentarIdPlanAlim)
                    .HasColumnName("Plano_Alimentar_idPlanAlim")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TanqueIdTanque)
                    .HasColumnName("Tanque_idTanque")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PlanoAlimentarIdPlanAlimNavigation)
                    .WithMany(p => p.RegAlimentar)
                    .HasForeignKey(d => d.PlanoAlimentarIdPlanAlim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Alimentar_Plano_Alimentar1");

                entity.HasOne(d => d.TanqueIdTanqueNavigation)
                    .WithMany(p => p.RegAlimentar)
                    .HasForeignKey(d => d.TanqueIdTanque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Alimentar_Tanque1");
                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");
            });

            modelBuilder.Entity<RegAmostragens>(entity =>
            {
                entity.HasKey(e => e.IdRegAmo);

                entity.ToTable("reg_amostragens");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Amostragens_Tanque1");

                entity.Property(e => e.IdRegAmo)
                    .HasColumnName("idRegAmo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.NroIndividuos)
                    .HasColumnName("nroIndividuos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PesoMedio).HasColumnName("pesoMedio");

                entity.Property(e => e.PesoTotal).HasColumnName("pesoTotal");

                entity.Property(e => e.TanqueIdTanque)
                    .HasColumnName("Tanque_idTanque")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TanqueIdTanqueNavigation)
                    .WithMany(p => p.RegAmostragens)
                    .HasForeignKey(d => d.TanqueIdTanque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Amostragens_Tanque1");
                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");
            });

            modelBuilder.Entity<RegCondAmb>(entity =>
            {
                entity.HasKey(e => e.IdRegCondAmb);

                entity.ToTable("reg_cond_amb");

                entity.HasIndex(e => e.CircuitoTanqueIdCircuito)
                    .HasName("fk_Reg_Cond_Amb_Circuito_Tanque1");

                entity.Property(e => e.IdRegCondAmb)
                    .HasColumnName("idRegCondAmb")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CircuitoTanqueIdCircuito)
                    .HasColumnName("Circuito_Tanque_idCircuito")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.NivelO2).HasColumnName("nivelO2");

                entity.Property(e => e.SalinidadeAgua).HasColumnName("salinidadeAgua");

                entity.Property(e => e.Temperatura).HasColumnName("temperatura");

                entity.Property(e => e.VolAgua).HasColumnName("volAgua");

                entity.HasOne(d => d.CircuitoTanqueIdCircuitoNavigation)
                    .WithMany(p => p.RegCondAmb)
                    .HasForeignKey(d => d.CircuitoTanqueIdCircuito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Cond_Amb_Circuito_Tanque1");
                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");
            });

            modelBuilder.Entity<RegManutencao>(entity =>
            {
                entity.HasKey(e => e.IdRegMan);

                entity.ToTable("reg_manutencao");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Manutencao_Tanque1");

                entity.HasIndex(e => e.TipoManuntecaoIdTManutencao)
                    .HasName("fk_Reg_Manutencao_Tipo_Manuntecao1");

                entity.Property(e => e.IdRegMan)
                    .HasColumnName("idRegMan")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.TanqueIdTanque)
                    .HasColumnName("Tanque_idTanque")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoManuntecaoIdTManutencao)
                    .HasColumnName("Tipo_Manuntecao_idT_Manutencao")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TanqueIdTanqueNavigation)
                    .WithMany(p => p.RegManutencao)
                    .HasForeignKey(d => d.TanqueIdTanque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Manutencao_Tanque1");

                entity.HasOne(d => d.TipoManuntecaoIdTManutencaoNavigation)
                    .WithMany(p => p.RegManutencao)
                    .HasForeignKey(d => d.TipoManuntecaoIdTManutencao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Manutencao_Tipo_Manuntecao1");

                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");
            });

            modelBuilder.Entity<RegNovosAnimais>(entity =>
            {
                entity.HasKey(e => e.IdRegAnimal);

                entity.ToTable("reg_novos_animais");

                entity.HasIndex(e => e.EspecieIdEspecie)
                    .HasName("fk_Reg_Novos_Animais_Especie1");

                entity.HasIndex(e => e.FornecedorIdFornColect)
                    .HasName("fk_Reg_Novos_Animais_Fornecedor1");

                entity.HasIndex(e => e.FuncionarioIdFuncionario)
                    .HasName("fk_Reg_Novos_Animais_Funcionario1");

                entity.HasIndex(e => e.FuncionarioIdFuncionario1)
                    .HasName("fk_Reg_Novos_Animais_Funcionario2");

                entity.HasIndex(e => e.LocalCapturaIdLocalCaptura)
                    .HasName("fk_Reg_Novos_Animais_LocalCaptura1");

                entity.HasIndex(e => e.TOrigemIdTOrigem)
                    .HasName("fk_Reg_Novos_Animais_T_Origem1");

                entity.HasIndex(e => e.TipoEstatutoGeneticoIdTipoEstatutoGenetico)
                    .HasName("fk_Reg_Novos_Animais_TipoEstatutoGenetico1");

                entity.Property(e => e.IdRegAnimal)
                    .HasColumnName("idRegAnimal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdicaoO2)
                    .HasColumnName("Adicao_O2")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Anestesico).HasColumnName("anestesico");

                entity.Property(e => e.Arejamento).HasColumnType("tinyint(1)");

                entity.Property(e => e.CompMedio).HasColumnName("compMedio");

                entity.Property(e => e.DataNasc)
                    .HasColumnName("dataNasc")
                    .HasColumnType("datetime");

                entity.Property(e => e.DuracaoViagem).HasColumnType("time");

                entity.Property(e => e.EspecieIdEspecie)
                    .HasColumnName("Especie_idEspecie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FornecedorIdFornColect)
                    .HasColumnName("Fornecedor_idFornColect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FuncionarioIdFuncionario)
                    .HasColumnName("Funcionario_idFuncionario");

                entity.Property(e => e.FuncionarioIdFuncionario1)
                    .HasColumnName("Funcionario_idFuncionario1");

                entity.Property(e => e.Gelo).HasColumnType("tinyint(1)");

                entity.Property(e => e.Idade)
                    .HasColumnName("idade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Imaturos).HasColumnType("int(11)");

                entity.Property(e => e.Juvenis).HasColumnType("int(11)");

                entity.Property(e => e.Larvas).HasColumnType("int(11)");

                entity.Property(e => e.LocalCapturaIdLocalCaptura)
                    .HasColumnName("LocalCaptura_idLocalCaptura")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NroCaixasIsoter)
                    .HasColumnName("nroCaixasIsoter")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NroContentores)
                    .HasColumnName("nroContentores")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NroExemplares)
                    .HasColumnName("nroExemplares")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NroFemeas)
                    .HasColumnName("nroFemeas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NroMachos)
                    .HasColumnName("nroMachos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NroMortosCheg)
                    .HasColumnName("nroMortosCheg")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ovos).HasColumnType("int(11)");

                entity.Property(e => e.PesoMedio).HasColumnName("pesoMedio");

                entity.Property(e => e.Refrigeracao)
                    .HasColumnName("refrigeracao")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.RespTransporte)
                    .HasColumnName("respTransporte")
                    .HasMaxLength(45);

                entity.Property(e => e.SatO2transp).HasColumnName("satO2Transp");

                entity.Property(e => e.sedacao)
                    .HasColumnName("sedacao")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.TOrigemIdTOrigem)
                    .HasColumnName("T_Origem_idT_Origem")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TempChegada)
                    .HasColumnName("tempChegada")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TempPartida)
                    .HasColumnName("tempPartida")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoContentor)
                    .HasColumnName("tipoContentor")
                    .HasMaxLength(45);

                entity.Property(e => e.TipoEstatutoGeneticoIdTipoEstatutoGenetico)
                    .HasColumnName("TipoEstatutoGenetico_idTipoEstatutoGenetico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VolAgua).HasColumnName("volAgua");

                entity.Property(e => e.VolContentor).HasColumnName("volContentor");

                entity.HasOne(d => d.EspecieIdEspecieNavigation)
                    .WithMany(p => p.RegNovosAnimais)
                    .HasForeignKey(d => d.EspecieIdEspecie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Novos_Animais_Especie1");

                entity.HasOne(d => d.FornecedorIdFornColectNavigation)
                    .WithMany(p => p.RegNovosAnimais)
                    .HasForeignKey(d => d.FornecedorIdFornColect)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Novos_Animais_Fornecedor1");

                entity.HasOne(d => d.FuncionarioIdFuncionarioNavigation)
                    .WithMany(p => p.RegNovosAnimaisFuncionarioIdFuncionarioNavigation)
                    .HasForeignKey(d => d.FuncionarioIdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Novos_Animais_Funcionario1");

                entity.HasOne(d => d.FuncionarioIdFuncionario1Navigation)
                    .WithMany(p => p.RegNovosAnimaisFuncionarioIdFuncionario1Navigation)
                    .HasForeignKey(d => d.FuncionarioIdFuncionario1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Novos_Animais_Funcionario2");

                entity.HasOne(d => d.LocalCapturaIdLocalCapturaNavigation)
                    .WithMany(p => p.RegNovosAnimais)
                    .HasForeignKey(d => d.LocalCapturaIdLocalCaptura)
                    .HasConstraintName("fk_Reg_Novos_Animais_LocalCaptura1");

                entity.HasOne(d => d.TOrigemIdTOrigemNavigation)
                    .WithMany(p => p.RegNovosAnimais)
                    .HasForeignKey(d => d.TOrigemIdTOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Novos_Animais_T_Origem1");

                entity.HasOne(d => d.TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation)
                    .WithMany(p => p.RegNovosAnimais)
                    .HasForeignKey(d => d.TipoEstatutoGeneticoIdTipoEstatutoGenetico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Novos_Animais_TipoEstatutoGenetico1");
            });

            modelBuilder.Entity<RegRemocoes>(entity =>
            {
                entity.HasKey(e => e.IdRegRemo);

                entity.ToTable("reg_remocoes");

                entity.HasIndex(e => e.MotivoIdMotivo)
                    .HasName("fk_Reg_Remocoes_Motivo1");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Remocoes_Tanque1");

                entity.Property(e => e.IdRegRemo)
                    .HasColumnName("idRegRemo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CausaMorte)
                    .HasColumnName("causaMorte")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.MotivoIdMotivo)
                    .HasColumnName("Motivo_idMotivo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NroRemocoes)
                    .HasColumnName("nroremocoes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TanqueIdTanque)
                    .HasColumnName("Tanque_idTanque")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.MotivoIdMotivoNavigation)
                    .WithMany(p => p.RegRemocoes)
                    .HasForeignKey(d => d.MotivoIdMotivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Remocoes_Motivo1");

                entity.HasOne(d => d.TanqueIdTanqueNavigation)
                    .WithMany(p => p.RegRemocoes)
                    .HasForeignKey(d => d.TanqueIdTanque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Remocoes_Tanque1");

                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");
            });

            modelBuilder.Entity<RegTratamento>(entity =>
            {
                entity.HasKey(e => e.IdRegTra);

                entity.ToTable("reg_tratamento");

                entity.HasIndex(e => e.AgenteTratIdAgenTra)
                    .HasName("fk_Reg_Tratamento_agente_Trat1");

                entity.HasIndex(e => e.FinalidadeIdFinalidade)
                    .HasName("fk_Reg_Tratamento_Finalidade1");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Tratamento_Tanque1");

                entity.Property(e => e.IdRegTra)
                    .HasColumnName("idRegTra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AgenteTratIdAgenTra)
                    .HasColumnName("agente_Trat_idAgenTra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConcAgenTra)
                    .HasColumnName("concAgenTra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinalidadeIdFinalidade)
                    .HasColumnName("Finalidade_idFinalidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TanqueIdTanque)
                    .HasColumnName("Tanque_idTanque")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tempo).HasColumnType("int(11)");

                entity.HasOne(d => d.AgenteTratIdAgenTraNavigation)
                    .WithMany(p => p.RegTratamento)
                    .HasForeignKey(d => d.AgenteTratIdAgenTra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Tratamento_agente_Trat1");

                entity.HasOne(d => d.FinalidadeIdFinalidadeNavigation)
                    .WithMany(p => p.RegTratamento)
                    .HasForeignKey(d => d.FinalidadeIdFinalidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Tratamento_Finalidade1");

                entity.HasOne(d => d.TanqueIdTanqueNavigation)
                    .WithMany(p => p.RegTratamento)
                    .HasForeignKey(d => d.TanqueIdTanque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Tratamento_Tanque1");
                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");
            });

            modelBuilder.Entity<Tanque>(entity =>
            {
                entity.HasKey(e => e.IdTanque);

                entity.ToTable("tanque");

                entity.HasIndex(e => e.CircuitoTanqueIdCircuito)
                    .HasName("fk_Tanque_Circuito_Tanque1_idx");

                entity.HasIndex(e => e.LoteIdLote)
                    .HasName("fk_Tanque_Lote1_idx");

                entity.Property(e => e.IdTanque)
                    .HasColumnName("idTanque")
                    .HasColumnType("int(11)");
                //codidenttanque
                entity.Property(e => e.codidenttanque)
                   .HasColumnName("codidenttanque")
                   .HasMaxLength(255);

                entity.Property(e => e.CircuitoTanqueIdCircuito)
                    .HasColumnName("Circuito_Tanque_idCircuito")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoteIdLote)
                    .HasColumnName("Lote_idLote")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NroAnimais)
                    .HasColumnName("nroAnimais")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observacoes)
                    .HasColumnName("observacoes")
                    .HasMaxLength(45);

                entity.Property(e => e.Sala)
                    .IsRequired()
                    .HasColumnName("sala")
                    .HasMaxLength(15);

                entity.HasOne(d => d.CircuitoTanqueIdCircuitoNavigation)
                    .WithMany(p => p.Tanque)
                    .HasForeignKey(d => d.CircuitoTanqueIdCircuito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tanque_Circuito_Tanque1");

                entity.HasOne(d => d.LoteIdLoteNavigation)
                    .WithMany(p => p.Tanque)
                    .HasForeignKey(d => d.LoteIdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tanque_Lote1");
                entity.Property(e => e.isarchived)
                   .HasColumnName("isarchived")
                   .HasColumnType("int(1)");
            });

            modelBuilder.Entity<Tipoestatutogenetico>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstatutoGenetico);

                entity.ToTable("tipoestatutogenetico");

                entity.Property(e => e.IdTipoEstatutoGenetico)
                    .HasColumnName("idTipoEstatutoGenetico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoEstatutoGeneticocol).HasMaxLength(45);
            });

            modelBuilder.Entity<TipoManuntecao>(entity =>
            {
                entity.HasKey(e => e.IdTManutencao);

                entity.ToTable("tipo_manuntecao");

                entity.Property(e => e.IdTManutencao)
                    .HasColumnName("idT_Manutencao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TManutencao)
                    .HasColumnName("T_Manutencao")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TOrigem>(entity =>
            {
                entity.HasKey(e => e.IdTOrigem);

                entity.ToTable("t_origem");

                entity.Property(e => e.IdTOrigem)
                    .HasColumnName("idT_Origem")
                    .HasColumnType("int(11)");

                entity.Property(e => e.descricao).HasMaxLength(45);
            });
        }
    }
}
