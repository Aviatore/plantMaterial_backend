using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace plantMaterials.Models
{
    public class PlantMaterialsContext : DbContext
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
        public virtual DbSet<ContainerType> ContainerTypes { get; set; }
        public virtual DbSet<Duplication> Duplications { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationType> LocationTypes { get; set; }
        public virtual DbSet<Phenotype> Phenotypes { get; set; }
        public virtual DbSet<PlantSample> PlantSamples { get; set; }
        public virtual DbSet<Population> Populations { get; set; }
        public virtual DbSet<Prep> Preps { get; set; }
        public virtual DbSet<PrepType> PrepTypes { get; set; }
        public virtual DbSet<ShelfPosition> ShelfPositions { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<SpeciesAlias> SpeciesAliases { get; set; }
        public virtual DbSet<Tissue> Tissues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=plant_materials;user id=sa;password=Gtm7dpi4zwt");
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

                entity.HasIndex(e => e.AnalysisTypeId, "IX_analyses_analysis_type_id");

                entity.HasIndex(e => e.PrepId, "IX_analyses_prep_id");

                entity.HasIndex(e => e.AnalysisId, "analyses_analysis_id_uindex")
                    .IsUnique();

                entity.Property(e => e.AnalysisId)
                    .HasColumnName("analysis_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AnalysisDate)
                    .HasColumnType("datetime")
                    .HasColumnName("analysis_date");

                entity.Property(e => e.AnalysisDescription).HasColumnName("analysis_description");

                entity.Property(e => e.AnalysisTypeId).HasColumnName("analysis_type_id");

                entity.Property(e => e.PrepId).HasColumnName("prep_id");

                entity.HasOne(d => d.AnalysisType)
                    .WithMany(p => p.Analyses)
                    .HasForeignKey(d => d.AnalysisTypeId)
                    .HasConstraintName("analyses_analysis_type__fk");

                entity.HasOne(d => d.Prep)
                    .WithMany(p => p.Analyses)
                    .HasForeignKey(d => d.PrepId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("analyses_prep__fk");
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

                entity.Property(e => e.AnalysisDescription).HasColumnName("analysis_description");

                entity.Property(e => e.AnalysisTypeName)
                    .HasMaxLength(100)
                    .HasColumnName("analysis_type_name");
            });

            modelBuilder.Entity<ContainerType>(entity =>
            {
                entity.HasKey(e => e.ContainerTypeId)
                    .HasName("container_types_pk")
                    .IsClustered(false);

                entity.ToTable("container_types");

                entity.HasIndex(e => e.ContainerTypeId, "container_types_container_type_id_uindex")
                    .IsUnique();

                entity.Property(e => e.ContainerTypeId)
                    .HasColumnName("container_type_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ContainerDescription).HasColumnName("container_description");

                entity.Property(e => e.ContainerTypeName)
                    .HasMaxLength(100)
                    .HasColumnName("container_type_name");
            });

            modelBuilder.Entity<Duplication>(entity =>
            {
                entity.HasKey(e => e.DuplicationId)
                    .HasName("duplications_pk")
                    .IsClustered(false);

                entity.ToTable("duplications");

                entity.HasIndex(e => e.DuplicationId, "duplications_duplication_id_uindex")
                    .IsUnique();

                entity.Property(e => e.DuplicationId)
                    .HasColumnName("duplication_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.DuplicationName).HasColumnName("duplication_name");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("locations_pk")
                    .IsClustered(false);

                entity.ToTable("locations");

                entity.HasIndex(e => e.LocationTypeId, "IX_locations_location_type_id");

                entity.HasIndex(e => e.LocationId, "locations_location_id_uindex")
                    .IsUnique();

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LocationDescription).HasColumnName("location_description");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(100)
                    .HasColumnName("location_name");

                entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");

                entity.HasOne(d => d.LocationType)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.LocationTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("locations_type__fk");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.HasKey(e => e.LocationTypeId)
                    .HasName("location_types_pk")
                    .IsClustered(false);

                entity.ToTable("location_types");

                entity.HasIndex(e => e.LocationTypeId, "location_types_location_type_id_uindex")
                    .IsUnique();

                entity.Property(e => e.LocationTypeId)
                    .HasColumnName("location_type_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LocationTypeName)
                    .HasMaxLength(100)
                    .HasColumnName("location_type_name");
            });

            modelBuilder.Entity<Phenotype>(entity =>
            {
                entity.HasKey(e => e.PhenotypeId)
                    .HasName("phenotypes_pk")
                    .IsClustered(false);

                entity.ToTable("phenotypes");

                entity.HasIndex(e => e.PhenotypeId, "phenotypes_phenotype_id_uindex")
                    .IsUnique();

                entity.Property(e => e.PhenotypeId)
                    .HasColumnName("phenotype_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PhenotypeDescription).HasColumnName("phenotype_description");

                entity.Property(e => e.PhenotypeName)
                    .HasMaxLength(100)
                    .HasColumnName("phenotype_name");
            });

            modelBuilder.Entity<PlantSample>(entity =>
            {
                entity.HasKey(e => e.PlantSampleId)
                    .HasName("plant_samples_pk")
                    .IsClustered(false);

                entity.ToTable("plant_samples");

                entity.HasIndex(e => e.DuplicationId, "IX_plant_samples_duplication_id");

                entity.HasIndex(e => e.LocationId, "IX_plant_samples_location_id");

                entity.HasIndex(e => e.PhenotypeId, "IX_plant_samples_phenotype_id");

                entity.HasIndex(e => e.PopulationId, "IX_plant_samples_population_id");

                entity.HasIndex(e => e.TissueId, "IX_plant_samples_tissue_id");

                entity.HasIndex(e => e.PlantSampleId, "plant_samples_plant_sample_id_uindex")
                    .IsUnique();

                entity.Property(e => e.PlantSampleId)
                    .HasColumnName("plant_sample_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CollectionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("collection_date");

                entity.Property(e => e.ContainerTypeId).HasColumnName("container_type_id");

                entity.Property(e => e.DuplicationId).HasColumnName("duplication_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.PhenotypeId).HasColumnName("phenotype_id");

                entity.Property(e => e.PlantSampleDescription).HasColumnName("plant_sample_description");

                entity.Property(e => e.PopulationId).HasColumnName("population_id");

                entity.Property(e => e.SampleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("sample_name");

                entity.Property(e => e.SampleWeight)
                    .HasMaxLength(50)
                    .HasColumnName("sample_weight");

                entity.Property(e => e.ShelfPositionId).HasColumnName("shelf_position_id");

                entity.Property(e => e.TissueId).HasColumnName("tissue_id");

                entity.HasOne(d => d.Duplication)
                    .WithMany(p => p.PlantSamples)
                    .HasForeignKey(d => d.DuplicationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("plant_samples_duplication__fk");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PlantSamples)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("plant_samples_location__fk");

                entity.HasOne(d => d.Phenotype)
                    .WithMany(p => p.PlantSamples)
                    .HasForeignKey(d => d.PhenotypeId)
                    .HasConstraintName("plant_samples_phenotype__fk");

                entity.HasOne(d => d.Population)
                    .WithMany(p => p.PlantSamples)
                    .HasForeignKey(d => d.PopulationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("plant_samples_population__fk");

                entity.HasOne(d => d.Tissue)
                    .WithMany(p => p.PlantSamples)
                    .HasForeignKey(d => d.TissueId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("plant_samples_tissue__fk");
            });

            modelBuilder.Entity<Population>(entity =>
            {
                entity.HasKey(e => e.PopulationId)
                    .HasName("populations_pk")
                    .IsClustered(false);

                entity.ToTable("populations");

                entity.HasIndex(e => e.SpeciesId, "IX_populations_species_id");

                entity.HasIndex(e => e.PopulationId, "populations_population_id_uindex")
                    .IsUnique();

                entity.Property(e => e.PopulationId)
                    .HasColumnName("population_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PopulationDescription).HasColumnName("population_description");

                entity.Property(e => e.PopulationName)
                    .HasMaxLength(100)
                    .HasColumnName("population_name");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.Populations)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("populations_species__fk");
            });

            modelBuilder.Entity<Prep>(entity =>
            {
                entity.HasKey(e => e.PrepId)
                    .HasName("preps_pk_2")
                    .IsClustered(false);

                entity.ToTable("preps");

                entity.HasIndex(e => e.PlantSampleId, "IX_preps_plant_sample_id");

                entity.HasIndex(e => e.PrepLocationId, "IX_preps_prep_location_id");

                entity.HasIndex(e => e.PrepTypeId, "IX_preps_prep_type_id");

                entity.HasIndex(e => e.PrepId, "preps_prep_id_uindex_2")
                    .IsUnique();

                entity.Property(e => e.PrepId)
                    .HasColumnName("prep_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ContainerTypeId).HasColumnName("container_type_id");

                entity.Property(e => e.DuplicationId).HasColumnName("duplication_id");

                entity.Property(e => e.IsolationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("isolation_date");

                entity.Property(e => e.PlantSampleId).HasColumnName("plant_sample_id");

                entity.Property(e => e.PrepDescription).HasColumnName("prep_description");

                entity.Property(e => e.PrepLocationId).HasColumnName("prep_location_id");

                entity.Property(e => e.PrepName)
                    .HasMaxLength(100)
                    .HasColumnName("prep_name");

                entity.Property(e => e.PrepTypeId).HasColumnName("prep_type_id");

                entity.Property(e => e.ShelfPositionId).HasColumnName("shelf_position_id");

                entity.Property(e => e.VolumeUl).HasColumnName("volume_ul");

                entity.HasOne(d => d.ContainerType)
                    .WithMany(p => p.Preps)
                    .HasForeignKey(d => d.ContainerTypeId)
                    .HasConstraintName("preps_container_type__fk");

                entity.HasOne(d => d.Duplication)
                    .WithMany(p => p.Preps)
                    .HasForeignKey(d => d.DuplicationId)
                    .HasConstraintName("preps_duplication__fk");

                entity.HasOne(d => d.PlantSample)
                    .WithMany(p => p.Preps)
                    .HasForeignKey(d => d.PlantSampleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("preps_plant_sample__fk");

                entity.HasOne(d => d.PrepLocation)
                    .WithMany(p => p.Preps)
                    .HasForeignKey(d => d.PrepLocationId)
                    .HasConstraintName("preps_location__fk");

                entity.HasOne(d => d.PrepType)
                    .WithMany(p => p.Preps)
                    .HasForeignKey(d => d.PrepTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("preps_type__fk");

                entity.HasOne(d => d.ShelfPosition)
                    .WithMany(p => p.Preps)
                    .HasForeignKey(d => d.ShelfPositionId)
                    .HasConstraintName("preps_shelf_position__fk");
            });

            modelBuilder.Entity<PrepType>(entity =>
            {
                entity.HasKey(e => e.PrepTypeId)
                    .HasName("preps_pk")
                    .IsClustered(false);

                entity.ToTable("prep_types");

                entity.HasIndex(e => e.PrepTypeId, "preps_prep_id_uindex")
                    .IsUnique();

                entity.Property(e => e.PrepTypeId)
                    .HasColumnName("prep_type_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PrepDescription).HasColumnName("prep_description");

                entity.Property(e => e.PrepTypeName)
                    .HasMaxLength(100)
                    .HasColumnName("prep_type_name");
            });

            modelBuilder.Entity<ShelfPosition>(entity =>
            {
                entity.HasKey(e => e.ShelfPositionId)
                    .HasName("shelf_positions_pk")
                    .IsClustered(false);

                entity.ToTable("shelf_positions");

                entity.HasIndex(e => e.ShelfPositionId, "shelf_positions_shelf_position_id_uindex")
                    .IsUnique();

                entity.Property(e => e.ShelfPositionId)
                    .HasColumnName("shelf_position_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ShelfPositionName).HasColumnName("shelf_position_name");
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

                entity.Property(e => e.SpeciesDescription).HasColumnName("species_description");

                entity.Property(e => e.SpeciesName)
                    .HasMaxLength(100)
                    .HasColumnName("species_name");
            });

            modelBuilder.Entity<SpeciesAlias>(entity =>
            {
                entity.HasKey(e => e.SpeciesAliasId)
                    .HasName("species_aliases_pk")
                    .IsClustered(false);

                entity.ToTable("species_aliases");

                entity.HasIndex(e => e.SpeciesId, "IX_species_aliases_species_id");

                entity.HasIndex(e => e.SpeciesAliasId, "species_aliases_species_alias_id_uindex")
                    .IsUnique();

                entity.Property(e => e.SpeciesAliasId)
                    .HasColumnName("species_alias_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.SpeciesAliases)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.Cascade)
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

                entity.Property(e => e.TissueDescription).HasColumnName("tissue_description");

                entity.Property(e => e.TissueName)
                    .HasMaxLength(100)
                    .HasColumnName("tissue_name");
            });
        }
    }
}
