using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace plantMaterials.Migrations
{
    public partial class snap1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "analysis_types",
                columns: table => new
                {
                    analysis_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    analysis_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    analysis_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("analysis_types_pk", x => x.analysis_type_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "container_types",
                columns: table => new
                {
                    container_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    container_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    container_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("container_types_pk", x => x.container_type_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "duplications",
                columns: table => new
                {
                    duplication_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    duplication_name = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("duplications_pk", x => x.duplication_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "location_types",
                columns: table => new
                {
                    location_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    location_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("location_types_pk", x => x.location_type_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "phenotypes",
                columns: table => new
                {
                    phenotype_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    phenotype_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phenotype_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("phenotypes_pk", x => x.phenotype_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "prep_types",
                columns: table => new
                {
                    prep_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    prep_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    prep_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("preps_pk", x => x.prep_type_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "sample_weights",
                columns: table => new
                {
                    weight_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    weight_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    weight_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("amounts_pk", x => x.weight_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "shelf_positions",
                columns: table => new
                {
                    shelf_position_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    shelf_position_name = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("shelf_positions_pk", x => x.shelf_position_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    species_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    species_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    species_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("species_pk", x => x.species_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "tissues",
                columns: table => new
                {
                    tissue_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    tissue_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tissue_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tissues_pk", x => x.tissue_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    location_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    location_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    shelf_position_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    location_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    container_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    location_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("locations_pk", x => x.location_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "locations_container__fk",
                        column: x => x.container_type_id,
                        principalTable: "container_types",
                        principalColumn: "container_type_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "locations_position__fk",
                        column: x => x.shelf_position_id,
                        principalTable: "shelf_positions",
                        principalColumn: "shelf_position_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "locations_type__fk",
                        column: x => x.location_type_id,
                        principalTable: "location_types",
                        principalColumn: "location_type_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "populations",
                columns: table => new
                {
                    population_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    population_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    population_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    species_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("populations_pk", x => x.population_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "populations_species__fk",
                        column: x => x.species_id,
                        principalTable: "species",
                        principalColumn: "species_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "species_aliases",
                columns: table => new
                {
                    species_alias_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    species_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("species_aliases_pk", x => x.species_alias_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "species_aliases_species__fk",
                        column: x => x.species_id,
                        principalTable: "species",
                        principalColumn: "species_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "plant_samples",
                columns: table => new
                {
                    plant_sample_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    collection_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    sample_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    population_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    plant_sample_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tissue_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    location_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    duplication_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    phenotype_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    sample_weight_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("plant_samples_pk", x => x.plant_sample_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "plant_samples_duplication__fk",
                        column: x => x.duplication_id,
                        principalTable: "duplications",
                        principalColumn: "duplication_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "plant_samples_location__fk",
                        column: x => x.location_id,
                        principalTable: "locations",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "plant_samples_phenotype__fk",
                        column: x => x.phenotype_id,
                        principalTable: "phenotypes",
                        principalColumn: "phenotype_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "plant_samples_population__fk",
                        column: x => x.population_id,
                        principalTable: "populations",
                        principalColumn: "population_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "plant_samples_tissue__fk",
                        column: x => x.tissue_id,
                        principalTable: "tissues",
                        principalColumn: "tissue_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "plant_samples_weight__fk",
                        column: x => x.sample_weight_id,
                        principalTable: "sample_weights",
                        principalColumn: "weight_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "preps",
                columns: table => new
                {
                    prep_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    prep_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    prep_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    plant_sample_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    prep_location_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    prep_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volume_ul = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("preps_pk_2", x => x.prep_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "preps_location__fk",
                        column: x => x.prep_location_id,
                        principalTable: "locations",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "preps_plant_sample__fk",
                        column: x => x.plant_sample_id,
                        principalTable: "plant_samples",
                        principalColumn: "plant_sample_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "preps_type__fk",
                        column: x => x.prep_type_id,
                        principalTable: "prep_types",
                        principalColumn: "prep_type_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "analyses",
                columns: table => new
                {
                    analysis_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    analysis_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    analysis_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    analysis_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prep_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("analyses_pk", x => x.analysis_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "analyses_analysis_type__fk",
                        column: x => x.analysis_type_id,
                        principalTable: "analysis_types",
                        principalColumn: "analysis_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "analyses_prep__fk",
                        column: x => x.prep_id,
                        principalTable: "preps",
                        principalColumn: "prep_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "analyses_analysis_id_uindex",
                table: "analyses",
                column: "analysis_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_analyses_analysis_type_id",
                table: "analyses",
                column: "analysis_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_analyses_prep_id",
                table: "analyses",
                column: "prep_id");

            migrationBuilder.CreateIndex(
                name: "analysis_types_analysis_type_id_uindex",
                table: "analysis_types",
                column: "analysis_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "container_types_container_type_id_uindex",
                table: "container_types",
                column: "container_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "duplications_duplication_id_uindex",
                table: "duplications",
                column: "duplication_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "location_types_location_type_id_uindex",
                table: "location_types",
                column: "location_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_locations_container_type_id",
                table: "locations",
                column: "container_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_locations_location_type_id",
                table: "locations",
                column: "location_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_locations_shelf_position_id",
                table: "locations",
                column: "shelf_position_id");

            migrationBuilder.CreateIndex(
                name: "locations_location_id_uindex",
                table: "locations",
                column: "location_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "phenotypes_phenotype_id_uindex",
                table: "phenotypes",
                column: "phenotype_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plant_samples_duplication_id",
                table: "plant_samples",
                column: "duplication_id");

            migrationBuilder.CreateIndex(
                name: "IX_plant_samples_location_id",
                table: "plant_samples",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_plant_samples_phenotype_id",
                table: "plant_samples",
                column: "phenotype_id");

            migrationBuilder.CreateIndex(
                name: "IX_plant_samples_population_id",
                table: "plant_samples",
                column: "population_id");

            migrationBuilder.CreateIndex(
                name: "IX_plant_samples_sample_weight_id",
                table: "plant_samples",
                column: "sample_weight_id");

            migrationBuilder.CreateIndex(
                name: "IX_plant_samples_tissue_id",
                table: "plant_samples",
                column: "tissue_id");

            migrationBuilder.CreateIndex(
                name: "plant_samples_plant_sample_id_uindex",
                table: "plant_samples",
                column: "plant_sample_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_populations_species_id",
                table: "populations",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "populations_population_id_uindex",
                table: "populations",
                column: "population_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "preps_prep_id_uindex",
                table: "prep_types",
                column: "prep_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_preps_plant_sample_id",
                table: "preps",
                column: "plant_sample_id");

            migrationBuilder.CreateIndex(
                name: "IX_preps_prep_location_id",
                table: "preps",
                column: "prep_location_id");

            migrationBuilder.CreateIndex(
                name: "IX_preps_prep_type_id",
                table: "preps",
                column: "prep_type_id");

            migrationBuilder.CreateIndex(
                name: "preps_prep_id_uindex_2",
                table: "preps",
                column: "prep_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "amounts_amount_id_uindex",
                table: "sample_weights",
                column: "weight_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "shelf_positions_shelf_position_id_uindex",
                table: "shelf_positions",
                column: "shelf_position_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "species_species_id_uindex",
                table: "species",
                column: "species_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_species_aliases_species_id",
                table: "species_aliases",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "species_aliases_species_alias_id_uindex",
                table: "species_aliases",
                column: "species_alias_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "tissues_tissue_id_uindex",
                table: "tissues",
                column: "tissue_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analyses");

            migrationBuilder.DropTable(
                name: "species_aliases");

            migrationBuilder.DropTable(
                name: "analysis_types");

            migrationBuilder.DropTable(
                name: "preps");

            migrationBuilder.DropTable(
                name: "plant_samples");

            migrationBuilder.DropTable(
                name: "prep_types");

            migrationBuilder.DropTable(
                name: "duplications");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "phenotypes");

            migrationBuilder.DropTable(
                name: "populations");

            migrationBuilder.DropTable(
                name: "tissues");

            migrationBuilder.DropTable(
                name: "sample_weights");

            migrationBuilder.DropTable(
                name: "container_types");

            migrationBuilder.DropTable(
                name: "shelf_positions");

            migrationBuilder.DropTable(
                name: "location_types");

            migrationBuilder.DropTable(
                name: "species");
        }
    }
}
