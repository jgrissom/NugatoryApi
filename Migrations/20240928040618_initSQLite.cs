using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NugatoryApi.Migrations
{
    /// <inheritdoc />
    public partial class initSQLite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    R = table.Column<int>(type: "INTEGER", nullable: false),
                    G = table.Column<int>(type: "INTEGER", nullable: false),
                    B = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
