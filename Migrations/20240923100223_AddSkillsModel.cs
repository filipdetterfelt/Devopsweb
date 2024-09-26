using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Devopsweb.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Title"},
                values: new object[,]
                {
                    { 1, "MySQL" },
                    { 2, "HTML" },
                    { 3, "CSS" },
                    { 4, "JavaScript" },
                    { 5, "Java" },
                    { 6, "Kotlin" },
                    { 7, "C#" },              
                    { 9, "JSON"},                
                    { 11, "Github" },
                    { 12, "Bootstrap" },
                    { 13, "Spring Framework" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
