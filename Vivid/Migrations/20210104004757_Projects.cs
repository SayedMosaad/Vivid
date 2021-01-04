using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vivid.Migrations
{
    public partial class Projects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photographer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concepts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConceptPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Planning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanningPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Realizatiion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealizationPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
