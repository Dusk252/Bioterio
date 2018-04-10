using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bioterio.Models
{
    public partial class BD_LesContext : DbContext
    {
        public virtual DbSet<AgenteTrat> AgenteTrat { get; set; }
        public virtual DbSet<CircuitoTanque> CircuitoTanque { get; set; }
        public virtual DbSet<Conselho> Conselho { get; set; }
        public virtual DbSet<Controlo> Controlo { get; set; }
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
        public virtual DbSet<Origem> Origem { get; set; }
        public virtual DbSet<PlanoAlimentar> PlanoAlimentar { get; set; }
        public virtual DbSet<Projeto> Projeto { get; set; }
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BD-Les;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgenteTrat>(entity =>
            {
                entity.HasKey(e => e.IdAgenTra);

                entity.ToTable("agente_trat");

                entity.Property(e => e.IdAgenTra)
                    .HasColumnName("idAgenTra")
                    .ValueGeneratedNever();

                entity.Property(e => e.NomeAgenTra)
                    .IsRequired()
                    .HasColumnName("nomeAgenTra")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CircuitoTanque>(entity =>
            {
                entity.HasKey(e => e.IdCircuito);

                entity.ToTable("circuito_tanque");

                entity.HasIndex(e => e.ProjetoIdProjeto)
                    .HasName("fk_Circuito_Tanque_Projeto1_idx");

                entity.Property(e => e.IdCircuito)
                    .HasColumnName("idCircuito")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodigoCircuito)
                    .HasColumnName("codigoCircuito")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("dataCriacao")
                    .HasColumnType("date");

                entity.Property(e => e.DataFinal)
                    .HasColumnName("dataFinal")
                    .HasColumnType("date");

                entity.Property(e => e.ProjetoIdProjeto).HasColumnName("Projeto_idProjeto");

                entity.Property(e => e.VarControlo)
                    .HasColumnName("varControlo")
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.ProjetoIdProjetoNavigation)
                    .WithMany(p => p.CircuitoTanque)
                    .HasForeignKey(d => d.ProjetoIdProjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Circuito_Tanque_Projeto1");
            });

            modelBuilder.Entity<Conselho>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.DistritoId });

                entity.ToTable("conselho");

                entity.HasIndex(e => e.DistritoId)
                    .HasName("fk_Conselho_Distrito1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DistritoId).HasColumnName("Distrito_id");

                entity.Property(e => e.NomeConselho)
                    .IsRequired()
                    .HasColumnName("nomeConselho")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Conselho)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Conselho_Distrito1");
            });

            modelBuilder.Entity<Controlo>(entity =>
            {
                entity.HasKey(e => new { e.EntryId, e.TableName, e.AttributeName });

                entity.ToTable("controlo");

                entity.Property(e => e.EntryId).HasColumnName("entry_id");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasColumnName("attribute_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LowerBound).HasColumnName("lower_bound");

                entity.Property(e => e.UpperBound).HasColumnName("upper_bound");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.ToTable("distrito");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NomeDistrito)
                    .HasColumnName("nomeDistrito")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Elementoequipa>(entity =>
            {
                entity.HasKey(e => e.ProjetoIdProjeto);

                entity.ToTable("elementoequipa");

                entity.HasIndex(e => e.FuncionarioIdFuncionario)
                    .HasName("fk_equipaProjeto_Funcionario1_idx");

                entity.Property(e => e.ProjetoIdProjeto)
                    .HasColumnName("Projeto_idProjeto")
                    .ValueGeneratedNever();

                entity.Property(e => e.FuncionarioIdFuncionario).HasColumnName("Funcionario_idFuncionario");

                entity.Property(e => e.Função)
                    .IsRequired()
                    .HasColumnName("função")
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.FuncionarioIdFuncionarioNavigation)
                    .WithMany(p => p.Elementoequipa)
                    .HasForeignKey(d => d.FuncionarioIdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipaProjeto_Funcionario1");

                entity.HasOne(d => d.ProjetoIdProjetoNavigation)
                    .WithOne(p => p.Elementoequipa)
                    .HasForeignKey<Elementoequipa>(d => d.ProjetoIdProjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipaProjeto_Projeto1");
            });

            modelBuilder.Entity<Ensaio>(entity =>
            {
                entity.HasKey(e => new { e.IdEnsaio, e.ProjetoIdProjeto });

                entity.ToTable("ensaio");

                entity.HasIndex(e => e.LoteIdLote)
                    .HasName("fk_Ensaio_Lote1_idx");

                entity.HasIndex(e => e.ProjetoIdProjeto)
                    .HasName("fk_Ensaio_Projeto1_idx");

                entity.Property(e => e.IdEnsaio).HasColumnName("idEnsaio");

                entity.Property(e => e.ProjetoIdProjeto).HasColumnName("Projeto_idProjeto");

                entity.Property(e => e.DataFim)
                    .HasColumnName("dataFim")
                    .HasColumnType("date");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("date");

                entity.Property(e => e.DescTratamento)
                    .IsRequired()
                    .HasColumnName("descTratamento")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.GrauSeveridade).HasColumnName("grauSeveridade");

                entity.Property(e => e.LoteIdLote).HasColumnName("Lote_idLote");

                entity.Property(e => e.MembroEquipaIdEquipa).HasColumnName("membroEquipa_idEquipa");

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
            });

            modelBuilder.Entity<Especie>(entity =>
            {
                entity.HasKey(e => new { e.IdEspecie, e.FamiliaIdFamilia, e.FamiliaGrupoIdGrupo });

                entity.ToTable("especie");

                entity.HasIndex(e => e.IdEspecie)
                    .HasName("UQ__especie__8E5AC249BF672312")
                    .IsUnique();

                entity.HasIndex(e => new { e.FamiliaIdFamilia, e.FamiliaGrupoIdGrupo })
                    .HasName("fk_Especie_Familia1_idx");

                entity.Property(e => e.IdEspecie).HasColumnName("idEspecie");

                entity.Property(e => e.FamiliaIdFamilia).HasColumnName("Familia_idFamilia");

                entity.Property(e => e.FamiliaGrupoIdGrupo).HasColumnName("Familia_Grupo_idGrupo");

                entity.Property(e => e.NomeCient)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NomeVulgar)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Familia)
                    .WithMany(p => p.Especie)
                    .HasForeignKey(d => new { d.FamiliaIdFamilia, d.FamiliaGrupoIdGrupo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Especie_Familia1");
            });

            modelBuilder.Entity<Familia>(entity =>
            {
                entity.HasKey(e => new { e.IdFamilia, e.GrupoIdGrupo });

                entity.ToTable("familia");

                entity.HasIndex(e => e.GrupoIdGrupo)
                    .HasName("fk_Familia_Grupo1_idx");

                entity.Property(e => e.IdFamilia).HasColumnName("idFamilia");

                entity.Property(e => e.GrupoIdGrupo).HasColumnName("Grupo_idGrupo");

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
                    .ValueGeneratedNever();

                entity.Property(e => e.TFinalidade)
                    .HasColumnName("T_Finalidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fornecedorcolector>(entity =>
            {
                entity.HasKey(e => e.IdFornColect);

                entity.ToTable("fornecedorcolector");

                entity.Property(e => e.IdFornColect)
                    .HasColumnName("idFornColect")
                    .ValueGeneratedNever();

                entity.Property(e => e.Morada)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nif).HasColumnName("NIF");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NroLicenca).HasColumnName("nroLicenca");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

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
                    .ValueGeneratedNever();

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasColumnName("nomeCompleto")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUtilizador)
                    .IsRequired()
                    .HasColumnName("nomeUtilizador")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.ToTable("grupo");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("idGrupo")
                    .ValueGeneratedNever();

                entity.Property(e => e.NomeGrupo)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Localcaptura>(entity =>
            {
                entity.HasKey(e => new { e.IdLocalCaptura, e.ConselhoId, e.ConselhoDistritoId });

                entity.ToTable("localcaptura");

                entity.HasIndex(e => new { e.ConselhoId, e.ConselhoDistritoId })
                    .HasName("fk_LocalCaptura_Conselho1_idx");

                entity.Property(e => e.IdLocalCaptura).HasColumnName("idLocalCaptura");

                entity.Property(e => e.ConselhoId).HasColumnName("Conselho_id");

                entity.Property(e => e.ConselhoDistritoId).HasColumnName("Conselho_Distrito_id");

                entity.Property(e => e.Localidade)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conselho)
                    .WithMany(p => p.Localcaptura)
                    .HasForeignKey(d => new { d.ConselhoId, d.ConselhoDistritoId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LocalCaptura_Conselho1");
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
                    .ValueGeneratedNever();

                entity.Property(e => e.CodigoLote)
                    .IsRequired()
                    .HasColumnName("codigoLote")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DataFim)
                    .HasColumnName("dataFim")
                    .HasColumnType("date");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("date");

                entity.Property(e => e.FuncionarioIdFuncionario).HasColumnName("Funcionario_idFuncionario");

                entity.Property(e => e.Observacoes)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.RegNovosAnimaisIdRegAnimal).HasColumnName("Reg_Novos_Animais_idRegAnimal");

                entity.Property(e => e.VarControlo)
                    .HasColumnName("varControlo")
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.LoteIdLotePrev).HasColumnName("Lote_idLote_prev");

                entity.Property(e => e.LoteIdLoteAtual).HasColumnName("Lote_idLote_atual");

                entity.Property(e => e.CodigoSubLote)
                    .IsRequired()
                    .HasColumnName("codigoSubLote")
                    .HasMaxLength(15)
                    .IsUnicode(false);

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
                    .ValueGeneratedNever();

                entity.Property(e => e.NomeMotivo)
                    .IsRequired()
                    .HasColumnName("nomeMotivo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoMotivo)
                    .IsRequired()
                    .HasColumnName("tipoMotivo")
                    .HasColumnType("nchar(1)");
            });

            modelBuilder.Entity<Origem>(entity =>
            {
                entity.HasKey(e => e.IdOrigem);

                entity.ToTable("origem");

                entity.Property(e => e.IdOrigem)
                    .HasColumnName("idOrigem")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<PlanoAlimentar>(entity =>
            {
                entity.HasKey(e => e.IdPlanAlim);

                entity.ToTable("plano_alimentar");

                entity.Property(e => e.IdPlanAlim)
                    .HasColumnName("idPlanAlim")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarcaAlim)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto);

                entity.ToTable("projeto");

                entity.Property(e => e.IdProjeto)
                    .HasColumnName("idProjeto")
                    .ValueGeneratedNever();

                entity.Property(e => e.AutorizacaoDgva)
                    .HasColumnName("AutorizacaoDGVA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DataFim)
                    .HasColumnName("dataFim")
                    .HasColumnType("date");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NroAnimaisAutoriz).HasColumnName("nroAnimaisAutoriz");

                entity.Property(e => e.RefOrbea).HasColumnName("RefORBEA");

                entity.Property(e => e.VarControlo)
                    .HasColumnName("varControlo")
                    .HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<RegAlimentar>(entity =>
            {
                entity.HasKey(e => new { e.IdRegAlim, e.TanqueIdTanque });

                entity.ToTable("reg_alimentar");

                entity.HasIndex(e => e.PlanoAlimentarIdPlanAlim)
                    .HasName("fk_Reg_Alimentar_Plano_Alimentar1_idx");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Alimentar_Tanque1_idx");

                entity.Property(e => e.IdRegAlim).HasColumnName("idRegAlim");

                entity.Property(e => e.TanqueIdTanque).HasColumnName("Tanque_idTanque");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.PlanoAlimentarIdPlanAlim).HasColumnName("Plano_Alimentar_idPlanAlim");

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
            });

            modelBuilder.Entity<RegAmostragens>(entity =>
            {
                entity.HasKey(e => new { e.IdRegAmo, e.TanqueIdTanque });

                entity.ToTable("reg_amostragens");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Amostragens_Tanque1_idx");

                entity.Property(e => e.IdRegAmo).HasColumnName("idRegAmo");

                entity.Property(e => e.TanqueIdTanque).HasColumnName("Tanque_idTanque");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.NroIndividuos).HasColumnName("nroIndividuos");

                entity.Property(e => e.PesoMedio).HasColumnName("pesoMedio");

                entity.Property(e => e.PesoTotal).HasColumnName("pesoTotal");

                entity.HasOne(d => d.TanqueIdTanqueNavigation)
                    .WithMany(p => p.RegAmostragens)
                    .HasForeignKey(d => d.TanqueIdTanque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Amostragens_Tanque1");
            });

            modelBuilder.Entity<RegCondAmb>(entity =>
            {
                entity.HasKey(e => new { e.IdRegCondAmb, e.CircuitoTanqueIdCircuito });

                entity.ToTable("reg_cond_amb");

                entity.HasIndex(e => e.CircuitoTanqueIdCircuito)
                    .HasName("fk_Reg_Cond_Amb_Circuito_Tanque1_idx");

                entity.Property(e => e.IdRegCondAmb).HasColumnName("idRegCondAmb");

                entity.Property(e => e.CircuitoTanqueIdCircuito).HasColumnName("Circuito_Tanque_idCircuito");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.NivelO2).HasColumnName("nivelO2");

                entity.Property(e => e.SalinidadeAgua).HasColumnName("salinidadeAgua");

                entity.Property(e => e.Temperatura).HasColumnName("temperatura");

                entity.Property(e => e.VolAgua).HasColumnName("volAgua");

                entity.HasOne(d => d.CircuitoTanqueIdCircuitoNavigation)
                    .WithMany(p => p.RegCondAmb)
                    .HasForeignKey(d => d.CircuitoTanqueIdCircuito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reg_Cond_Amb_Circuito_Tanque1");
            });

            modelBuilder.Entity<RegManutencao>(entity =>
            {
                entity.HasKey(e => new { e.IdRegMan, e.TanqueIdTanque });

                entity.ToTable("reg_manutencao");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Manutencao_Tanque1_idx");

                entity.HasIndex(e => e.TipoManuntecaoIdTManutencao)
                    .HasName("fk_Reg_Manutencao_Tipo_Manuntecao1_idx");

                entity.Property(e => e.IdRegMan).HasColumnName("idRegMan");

                entity.Property(e => e.TanqueIdTanque).HasColumnName("Tanque_idTanque");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.TipoManuntecaoIdTManutencao).HasColumnName("Tipo_Manuntecao_idT_Manutencao");

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
            });

            modelBuilder.Entity<RegNovosAnimais>(entity =>
            {
                entity.HasKey(e => e.IdRegAnimal);

                entity.ToTable("reg_novos_animais");

                entity.HasIndex(e => e.EspecieIdEspecie)
                    .HasName("fk_Reg_Novos_Animais_Especie1_idx");

                entity.HasIndex(e => e.FornecedorIdFornColect)
                    .HasName("fk_Reg_Novos_Animais_Fornecedor1_idx");

                entity.HasIndex(e => e.FuncionarioIdFuncionario)
                    .HasName("fk_Reg_Novos_Animais_Funcionario1_idx");

                entity.HasIndex(e => e.FuncionarioIdFuncionario1)
                    .HasName("fk_Reg_Novos_Animais_Funcionario2_idx");

                entity.HasIndex(e => e.LocalCapturaIdLocalCaptura)
                    .HasName("fk_Reg_Novos_Animais_LocalCaptura1_idx");

                entity.HasIndex(e => e.TOrigemIdTOrigem)
                    .HasName("fk_Reg_Novos_Animais_T_Origem1_idx");

                entity.HasIndex(e => e.TipoEstatutoGeneticoIdTipoEstatutoGenetico)
                    .HasName("fk_Reg_Novos_Animais_TipoEstatutoGenetico1_idx");

                entity.Property(e => e.IdRegAnimal)
                    .HasColumnName("idRegAnimal")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdicaoO2).HasColumnName("Adicao_O2");

                entity.Property(e => e.Anestesico).HasColumnName("anestesico");

                entity.Property(e => e.CompMedio).HasColumnName("compMedio");

                entity.Property(e => e.DataNasc)
                    .HasColumnName("dataNasc")
                    .HasColumnType("date");

                entity.Property(e => e.EspecieIdEspecie).HasColumnName("Especie_idEspecie");

                entity.Property(e => e.FornecedorIdFornColect).HasColumnName("Fornecedor_idFornColect");

                entity.Property(e => e.FuncionarioIdFuncionario).HasColumnName("Funcionario_idFuncionario");

                entity.Property(e => e.FuncionarioIdFuncionario1).HasColumnName("Funcionario_idFuncionario1");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.LocalCapturaIdLocalCaptura).HasColumnName("LocalCaptura_idLocalCaptura");

                entity.Property(e => e.NroCaixasIsoter).HasColumnName("nroCaixasIsoter");

                entity.Property(e => e.NroContentores).HasColumnName("nroContentores");

                entity.Property(e => e.NroExemplares).HasColumnName("nroExemplares");

                entity.Property(e => e.NroFemeas).HasColumnName("nroFemeas");

                entity.Property(e => e.NroMachos).HasColumnName("nroMachos");

                entity.Property(e => e.NroMortosCheg).HasColumnName("nroMortosCheg");

                entity.Property(e => e.PesoMedio).HasColumnName("pesoMedio");

                entity.Property(e => e.Refrigeracao).HasColumnName("refrigeracao");

                entity.Property(e => e.RespTransporte)
                    .HasColumnName("respTransporte")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SatO2transp).HasColumnName("satO2Transp");

                entity.Property(e => e.Sedação).HasColumnName("sedação");

                entity.Property(e => e.TOrigemIdTOrigem).HasColumnName("T_Origem_idT_Origem");

                entity.Property(e => e.TempChegada).HasColumnName("tempChegada");

                entity.Property(e => e.TempPartida).HasColumnName("tempPartida");

                entity.Property(e => e.TipoContentor)
                    .HasColumnName("tipoContentor")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoEstatutoGeneticoIdTipoEstatutoGenetico).HasColumnName("TipoEstatutoGenetico_idTipoEstatutoGenetico");

                entity.Property(e => e.VolAgua).HasColumnName("volAgua");

                entity.Property(e => e.VolContentor).HasColumnName("volContentor");
            });

            modelBuilder.Entity<RegRemocoes>(entity =>
            {
                entity.HasKey(e => new { e.IdRegRemo, e.TanqueIdTanque });

                entity.ToTable("reg_remocoes");

                entity.HasIndex(e => e.MotivoIdMotivo)
                    .HasName("fk_Reg_Remocoes_Motivo1_idx");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Remocoes_Tanque1_idx");

                entity.Property(e => e.IdRegRemo).HasColumnName("idRegRemo");

                entity.Property(e => e.TanqueIdTanque).HasColumnName("Tanque_idTanque");

                entity.Property(e => e.CausaMorte)
                    .HasColumnName("causaMorte")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.MotivoIdMotivo).HasColumnName("Motivo_idMotivo");

                entity.Property(e => e.NroRemoções).HasColumnName("nroRemoções");
            });

            modelBuilder.Entity<RegTratamento>(entity =>
            {
                entity.HasKey(e => new { e.IdRegTra, e.TanqueIdTanque });

                entity.ToTable("reg_tratamento");

                entity.HasIndex(e => e.AgenteTratIdAgenTra)
                    .HasName("fk_Reg_Tratamento_agente_Trat1_idx");

                entity.HasIndex(e => e.FinalidadeIdFinalidade)
                    .HasName("fk_Reg_Tratamento_Finalidade1_idx");

                entity.HasIndex(e => e.TanqueIdTanque)
                    .HasName("fk_Reg_Tratamento_Tanque1_idx");

                entity.Property(e => e.IdRegTra).HasColumnName("idRegTra");

                entity.Property(e => e.TanqueIdTanque).HasColumnName("Tanque_idTanque");

                entity.Property(e => e.AgenteTratIdAgenTra).HasColumnName("agente_Trat_idAgenTra");

                entity.Property(e => e.ConcAgenTra).HasColumnName("concAgenTra");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.FinalidadeIdFinalidade).HasColumnName("Finalidade_idFinalidade");

                entity.Property(e => e.Tempo).HasColumnType("time(6)");
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
                    .ValueGeneratedNever();

                entity.Property(e => e.CircuitoTanqueIdCircuito).HasColumnName("Circuito_Tanque_idCircuito");

                entity.Property(e => e.LoteIdLote).HasColumnName("Lote_idLote");

                entity.Property(e => e.NroAnimais).HasColumnName("nroAnimais");

                entity.Property(e => e.Observacoes)
                    .HasColumnName("observacoes")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sala)
                    .IsRequired()
                    .HasColumnName("sala")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.VarControlo)
                    .HasColumnName("varControlo")
                    .HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<Tipoestatutogenetico>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstatutoGenetico);

                entity.ToTable("tipoestatutogenetico");

                entity.Property(e => e.IdTipoEstatutoGenetico)
                    .HasColumnName("idTipoEstatutoGenetico")
                    .ValueGeneratedNever();

                entity.Property(e => e.TipoEstatutoGeneticocol)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoManuntecao>(entity =>
            {
                entity.HasKey(e => e.IdTManutencao);

                entity.ToTable("tipo_manuntecao");

                entity.Property(e => e.IdTManutencao)
                    .HasColumnName("idT_Manutencao")
                    .ValueGeneratedNever();

                entity.Property(e => e.TManutencao)
                    .HasColumnName("T_Manutencao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TOrigem>(entity =>
            {
                entity.HasKey(e => e.IdTOrigem);

                entity.ToTable("t_origem");

                entity.Property(e => e.IdTOrigem)
                    .HasColumnName("idT_Origem")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrição)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
