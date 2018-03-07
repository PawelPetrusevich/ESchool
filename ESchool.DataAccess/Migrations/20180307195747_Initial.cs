using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ESchool.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccauntDbModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatersDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Loggin = table.Column<string>(nullable: true),
                    ModifierDate = table.Column<DateTime>(nullable: true),
                    ModifierId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccauntDbModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityDbModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true),
                    CreatersDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    ModifierDate = table.Column<DateTime>(nullable: true),
                    ModifierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDbModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectOfInstructionsDbModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatersDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    InstructionName = table.Column<string>(nullable: true),
                    ModifierDate = table.Column<DateTime>(nullable: true),
                    ModifierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectOfInstructionsDbModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccauntSettingsDbModels",
                columns: table => new
                {
                    AccauntId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: true),
                    ClassId = table.Column<int>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    SchoolId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccauntSettingsDbModels", x => x.AccauntId);
                    table.ForeignKey(
                        name: "FK_AccauntSettingsDbModels_AccauntDbModels_AccauntId",
                        column: x => x.AccauntId,
                        principalTable: "AccauntDbModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstutionDbModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CreatersDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    ModifierDate = table.Column<DateTime>(nullable: true),
                    ModifierId = table.Column<int>(nullable: true),
                    SchoolAdress = table.Column<string>(nullable: true),
                    SchoolNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstutionDbModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstutionDbModels_CityDbModel_Id",
                        column: x => x.Id,
                        principalTable: "CityDbModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccauntSettingsDbModels");

            migrationBuilder.DropTable(
                name: "InstutionDbModels");

            migrationBuilder.DropTable(
                name: "SubjectOfInstructionsDbModels");

            migrationBuilder.DropTable(
                name: "AccauntDbModels");

            migrationBuilder.DropTable(
                name: "CityDbModel");
        }
    }
}
