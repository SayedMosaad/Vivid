using Microsoft.EntityFrameworkCore.Migrations;

namespace Vivid.Migrations
{
    public partial class Profile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plan1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plan2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FindUs = table.Column<int>(type: "int", nullable: false),
                    UniqueProject = table.Column<int>(type: "int", nullable: false),
                    Parts = table.Column<int>(type: "int", nullable: false),
                    Achivements = table.Column<int>(type: "int", nullable: false),
                    Countries = table.Column<int>(type: "int", nullable: false),
                    ProjectInProgress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
