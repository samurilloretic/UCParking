using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UCP.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parqueaderos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picoPlaca = table.Column<int>(type: "int", nullable: false),
                    numeroPuestos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parqueaderos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehiculos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "puestos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puestos", x => x.id);
                    table.ForeignKey(
                        name: "FK_puestos_parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identificacion = table.Column<int>(type: "int", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condicionEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vehiculo_1id = table.Column<int>(type: "int", nullable: true),
                    Vehiculo_2id = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true),
                    tarifaAdministrativo = table.Column<float>(type: "real", nullable: true),
                    unidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oficina = table.Column<int>(type: "int", nullable: true),
                    tarifaEstudiante = table.Column<float>(type: "real", nullable: true),
                    programa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tarifaProfesor = table.Column<float>(type: "real", nullable: true),
                    facultad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cubiculo = table.Column<int>(type: "int", nullable: true),
                    tarifaVisitante = table.Column<float>(type: "real", nullable: true),
                    autoriza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actividad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_personas_parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_vehiculos_Vehiculo_1id",
                        column: x => x.Vehiculo_1id,
                        principalTable: "vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_vehiculos_Vehiculo_2id",
                        column: x => x.Vehiculo_2id,
                        principalTable: "vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transacciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vehiculoid = table.Column<int>(type: "int", nullable: true),
                    personaid = table.Column<int>(type: "int", nullable: true),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_transacciones_parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transacciones_personas_personaid",
                        column: x => x.personaid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transacciones_vehiculos_vehiculoid",
                        column: x => x.vehiculoid,
                        principalTable: "vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personas_Parqueaderoid",
                table: "personas",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_personas_Vehiculo_1id",
                table: "personas",
                column: "Vehiculo_1id");

            migrationBuilder.CreateIndex(
                name: "IX_personas_Vehiculo_2id",
                table: "personas",
                column: "Vehiculo_2id");

            migrationBuilder.CreateIndex(
                name: "IX_puestos_Parqueaderoid",
                table: "puestos",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_transacciones_Parqueaderoid",
                table: "transacciones",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_transacciones_personaid",
                table: "transacciones",
                column: "personaid");

            migrationBuilder.CreateIndex(
                name: "IX_transacciones_vehiculoid",
                table: "transacciones",
                column: "vehiculoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "puestos");

            migrationBuilder.DropTable(
                name: "transacciones");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "parqueaderos");

            migrationBuilder.DropTable(
                name: "vehiculos");
        }
    }
}
