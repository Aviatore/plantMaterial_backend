using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace plantMaterials.Models
{
    public partial class PlantMaterialsContext : DbContext
    {
        public PlantMaterialsContext()
        {
        }

        public PlantMaterialsContext(DbContextOptions<PlantMaterialsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Analysis> Analyses { get; set; }
        public virtual DbSet<AnalysisType> AnalysisTypes { get; set; }
        public virtual DbSet<PlantSample> PlantSamples { get; set; }
        public virtual DbSet<Population> Populations { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<SpeciesAlias> SpeciesAliases { get; set; }
        public virtual DbSet<Tissue> Tissues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;user id=sa;password=Gtm7dpi4zwt;database=plant_materials");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Analysis>(entity =>
            {
                entity.HasKey(e => e.AnalysisId)
                    .HasName("analyses_pk")
                    .IsClustered(false);

                entity.ToTable("analyses");

                entity.HasIndex(e => e.AnalysisId, "analyses_analysis_id_uindex")
                    .IsUnique();

                entity.Property(e => e.AnalysisId)
                    .HasColumnName("analysis_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AnalysisDate)
                    .HasColumnType("datetime")
                    .HasColumnName("analysis_date");

                entity.Property(e => e.AnalysisTypeId).HasColumnName("analysis_type_id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.PlantSampleId).HasColumnName("plant_sample_id");

                entity.HasOne(d => d.AnalysisType)
                    .WithMany(p => p.Analyses)
                    .HasForeignKey(d => d.AnalysisTypeId)
                    .HasConstraintName("analyses_analysis_type__fk");

                entity.HasOne(d => d.PlantSample)
                    .WithMany(p => p.Analyses)
                    .HasForeignKey(d => d.PlantSampleId)
                    .HasConstraintName("analyses_plant__fk");
            });

            modelBuilder.Entity<AnalysisType>(entity =>
            {
                entity.HasKey(e => e.AnalysisTypeId)
                    .HasName("analysis_types_pk")
                    .IsClustered(false);

                entity.ToTable("analysis_types");

                entity.HasIndex(e => e.AnalysisTypeId, "analysis_types_analysis_type_id_uindex")
                    .IsUnique();

                entity.Property(e => e.AnalysisTypeId)
                    .HasColumnName("analysis_type_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AnalysisTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("analysis_type_name");
            });

            modelBuilder.Entity<PlantSample>(entity =>
            {
                entity.HasKey(e => e.PlantSampleId)
                    .HasName("plant_samples_pk")
                    .IsClustered(false);

                entity.ToTable("plant_samples");

                entity.HasIndex(e => e.PlantSampleId, "plant_samples_plant_sample_id_uindex")
                    .IsUnique();

                entity.Property(e => e.PlantSampleId)
                    .HasColumnName("plant_sample_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CollectionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("collection_date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.PlantName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("plant_name");

                entity.Property(e => e.PopulationId).HasColumnName("population_id");

                entity.HasOne(d => d.Population)
                    .WithMany(p => p.PlantSamples)
                    .HasForeignKey(d => d.PopulationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("plant_samples_population__fk");
            });

            modelBuilder.Entity<Population>(entity =>
            {
                entity.HasKey(e => e.PopulationId)
                    .HasName("populations_pk")
                    .IsClustered(false);

                entity.ToTable("populations");

                entity.HasIndex(e => e.PopulationId, "populations_population_id_uindex")
                    .IsUnique();

                entity.Property(e => e.PopulationId)
                    .HasColumnName("population_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.PopulationName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("population_name");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.Property(e => e.TissueId).HasColumnName("tissue_id");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.Populations)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("populations_species__fk");

                entity.HasOne(d => d.Tissue)
                    .WithMany(p => p.Populations)
                    .HasForeignKey(d => d.TissueId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("populations_tissue__fk");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.HasKey(e => e.SpeciesId)
                    .HasName("species_pk")
                    .IsClustered(false);

                entity.ToTable("species");

                entity.HasIndex(e => e.SpeciesId, "species_species_id_uindex")
                    .IsUnique();

                entity.Property(e => e.SpeciesId)
                    .HasColumnName("species_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.SpeciesName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("species_name");
            });

            modelBuilder.Entity<SpeciesAlias>(entity =>
            {
                entity.HasKey(e => e.SpeciesAliasId)
                    .HasName("species_aliases_pk")
                    .IsClustered(false);

                entity.ToTable("species_aliases");

                entity.HasIndex(e => e.SpeciesAliasId, "species_aliases_species_alias_id_uindex")
                    .IsUnique();

                entity.Property(e => e.SpeciesAliasId)
                    .HasColumnName("species_alias_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("alias");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.SpeciesAliases)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("species_aliases_species__fk");
            });

            modelBuilder.Entity<Tissue>(entity =>
            {
                entity.HasKey(e => e.TissueId)
                    .HasName("tissues_pk")
                    .IsClustered(false);

                entity.ToTable("tissues");

                entity.HasIndex(e => e.TissueId, "tissues_tissue_id_uindex")
                    .IsUnique();

                entity.Property(e => e.TissueId)
                    .HasColumnName("tissue_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.TissueName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tissue_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
