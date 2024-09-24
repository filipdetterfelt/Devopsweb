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
                columns: new[] { "Id", "Title", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "MySQL","Images/mysql.png" },
                    { 2, "HTML","Images/html.png" },
                    { 3, "CSS","Images/css.png" },
                    { 4, "JavaScript" , "Images/javascript.png"},
                    { 5, "Java" , "Images/java.png"},
                    { 6, "Kotlin" , "Images/kotlin.png"},
                    { 7, "C#" , "Images/csharp.png"},              
                    { 9, "JSON","Images/json.png" },                
                    { 11, "Github","Images/github.png" },
                    { 12, "Bootstrap","Images/bootstrap.png" },
                    { 13, "Spring Framework","Images/spring.png" }
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
