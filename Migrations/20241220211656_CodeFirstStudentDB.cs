using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCodeFirst_01.Migrations
{
    public partial class CodeFirstStudentDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "varchar(50)", nullable: true),
                    StudentGender = table.Column<string>(type: "varchar(20)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Standard = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsDB", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsDB");
        }
    }
}
